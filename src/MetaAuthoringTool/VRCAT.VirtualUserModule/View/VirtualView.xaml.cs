using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using MVRWrapper;

namespace VRCAT.VirtualUserModule
{
    /// <summary>
    /// VirtualView UI
    /// </summary>
    public partial class VirtualView : Window , IDropTarget
    {
        MContainer _engageObject;
        float _savedX;
        float _savedY;
        float _savedZ;
        /// <summary>
        /// 생성자
        /// </summary>
        public VirtualView()
        {
            InitializeComponent();
            this.Loaded += new System.Windows.RoutedEventHandler(View_Loaded);
            this.MouseMove += new System.Windows.Input.MouseEventHandler(View_MouseMove);
            this.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(View_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(View_MouseLeftButtonUp);
            this.Closing += VirtualView_Closing;
        }

        void VirtualView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_engageObject != null)
            {
                this._engageObject.Transform.Rotation.X = _savedX;
                this._engageObject.Transform.Rotation.Y = _savedY;
                this._engageObject.Transform.Rotation.Z = _savedZ;
                this._engageObject = null;
                this._engageObjectText.Text = "연결된 오브젝트가 없습니다.";
                this._engageObjectText.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));

                this.headYRotation.Angle = 0;
                this.headXRotation.Angle = 0;
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("EngineRefresh");
            }
            e.Cancel = true;
            Visibility = Visibility.Hidden;
        }

        private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Make the axes.
            const double tic_diameter = 0.2;
            // X = Red.
            ModelVisual3D modelVisual3D = new ModelVisual3D();
            MeshGeometry3D axis_mesh = new MeshGeometry3D();
            axis_mesh.AddAxis(new Point3D(-100, 0, 0), new Point3D(100, 0, 0),
                new Vector3D(0, 1, 0), tic_diameter, 1.0);
            DiffuseMaterial axis_material = new DiffuseMaterial(Brushes.Red);
            modelVisual3D.Content = new GeometryModel3D(axis_mesh, axis_material);
            this.World.Children.Add(modelVisual3D);

            // Y = Green.
            modelVisual3D = new ModelVisual3D();
            axis_mesh = new MeshGeometry3D();
            axis_mesh.AddAxis(new Point3D(), new Point3D(0, 100, 0),
                new Vector3D(0, 1, 0), tic_diameter, 1.0);
            axis_material = new DiffuseMaterial(Brushes.Green);
            modelVisual3D.Content = new GeometryModel3D(axis_mesh, axis_material);
            this.World.Children.Add(modelVisual3D);

            // Z = Blue.
            modelVisual3D = new ModelVisual3D();
            axis_mesh = new MeshGeometry3D();
            axis_mesh.AddAxis(new Point3D(0, 0, -100), new Point3D(0, 0, 100),
                new Vector3D(0, 1, 0), tic_diameter, 1.0);
            axis_material = new DiffuseMaterial(Brushes.Blue);
            modelVisual3D.Content = new GeometryModel3D(axis_mesh, axis_material);
            this.World.Children.Add(modelVisual3D);

        }


        Point lastPoint = new Point();
        private void View_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            // TODO: Add event handler implementation here.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPt = e.GetPosition(this);
                double moveX = currentPt.X - lastPoint.X;
                double moveY = currentPt.Y - lastPoint.Y;
                this.lastPoint = currentPt;

                double angleY = this.headYRotation.Angle + moveX;
                angleY = Math.Min(90, angleY);
                angleY = Math.Max(-90, angleY);
                double angleX = this.headXRotation.Angle + moveY;
                angleX = Math.Min(80, angleX);
                angleX = Math.Max(-45, angleX);

//                 float realMoveX = (float)(angleX - this.headXRotation.Angle);
//                 float realMoveY = (float)(angleY - this.headYRotation.Angle);

/*                this._engageObjectText.Text = string.Format("({0:F2},{1:F2}) ({2:F2},{3:F2}) ({4:F2},{5:F2})", moveX, moveY, angleX, angleY);*/
                this.headYRotation.Angle = angleY;
                this.headXRotation.Angle = angleX;

//                 if (this._engageObject == null)
//                 {
//                     MVRScene scene = MVREngine.GetEngine().GetCurScene();
//                     if (scene != null)
//                     {
//                         this._engageObject = scene.FindObject("MainCamera");
//                     }
//                 }
                if (this._engageObject != null)
                {
                    //MVRVector3 rot = this._engageObject.Transform.Rotation;
                    this._engageObject.Transform.Rotation.Z = (float)angleX;
                    this._engageObject.Transform.Rotation.X = (float)angleY;
                    //this._engageObject.Transform.Rotation.Z = this._savedRotation.Z;
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("InspectorUpdateEvent");
                }
            }
        }

        private void View_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.lastPoint = e.GetPosition(this);
            Mouse.Capture(this);

        }

        private void View_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Mouse.Capture(null);
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataModel.NodeVM)
                dropInfo.Effects = DragDropEffects.Copy;
        }

        public void Drop(IDropInfo dropInfo)
        {
            if(dropInfo.Data is DataModel.NodeVM)
            {
                this._engageObject = (MContainer)((DataModel.NodeVM)dropInfo.Data).NodeObject;
                //this._savedRotation = this._engageObject.Transform.Rotation;
                this._savedX = _engageObject.Transform.Rotation.X;
                this._savedY = _engageObject.Transform.Rotation.Y;
                this._savedZ = _engageObject.Transform.Rotation.Z;
                this._engageObjectText.Text = this._engageObject.Name;
                this._engageObjectText.Foreground = new SolidColorBrush(Color.FromRgb(255,255,0));
            }
        }

        private void UnengageButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._engageObject != null)
            {
                //this._engageObject.Transform.Rotation = this._savedRotation;
                this._engageObject.Transform.Rotation.X = this._savedX;
                this._engageObject.Transform.Rotation.Y = this._savedY;
                this._engageObject.Transform.Rotation.Z = this._savedZ;
                this._engageObject = null;
                this._engageObjectText.Text = "연결된 오브젝트가 없습니다.";
                this._engageObjectText.Foreground = new SolidColorBrush(Color.FromRgb(100, 100, 100));

                this.headYRotation.Angle = 0;
                this.headXRotation.Angle = 0;
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("EngineRefresh");
            }
        }

    }
    /// <summary>
    /// Virtual Head 생성을 위한 MeshExtensions
    /// </summary>
    public static class MeshExtensions
    {
        // Return a MeshGeometry3D representing this mesh's triangle normals.
        public static MeshGeometry3D ToVertexNormals(this MeshGeometry3D mesh,
            double length, double thickness)
        {
            // Copy existing vertex normals.
            Vector3D[] vertex_normals = new Vector3D[mesh.Positions.Count];
            for (int i = 0; i < mesh.Normals.Count; i++)
                vertex_normals[i] = mesh.Normals[i];

            // Calculate missing vetex normals.
            for (int vertex = mesh.Normals.Count; vertex < mesh.Positions.Count; vertex++)
            {
                Vector3D total_vector = new Vector3D(0, 0, 0);
                int num_triangles = 0;

                // Find the triangles that contain this vertex.
                for (int triangle = 0; triangle < mesh.TriangleIndices.Count; triangle += 3)
                {
                    // See if this triangle contains the vertex.
                    int vertex1 = mesh.TriangleIndices[triangle];
                    int vertex2 = mesh.TriangleIndices[triangle + 1];
                    int vertex3 = mesh.TriangleIndices[triangle + 2];
                    if ((vertex1 == vertex) ||
                        (vertex2 == vertex) ||
                        (vertex3 == vertex))
                    {
                        // This triangle contains this vertex.
                        // Calculate its surface normal.
                        Vector3D normal = FindTriangleNormal(
                            mesh.Positions[vertex1],
                            mesh.Positions[vertex2],
                            mesh.Positions[vertex3]);

                        // Add the new normal to the total.
                        total_vector = new Vector3D(
                            total_vector.X + normal.X,
                            total_vector.Y + normal.Y,
                            total_vector.Z + normal.Z);
                        num_triangles++;
                    }
                }

                // Set the vertex's normal.
                if (num_triangles > 0)
                    vertex_normals[vertex] = new Vector3D(
                        total_vector.X / num_triangles,
                        total_vector.Y / num_triangles,
                        total_vector.Z / num_triangles);
            }

            // Make a mesh to hold the normals.
            MeshGeometry3D normals = new MeshGeometry3D();

            // Convert the normal vectors into segments.
            for (int i = 0; i < mesh.Positions.Count; i++)
            {
                // Set the normal vector's length.
                vertex_normals[i] = ScaleVector(vertex_normals[i], length);

                // Find the other end point.
                Point3D endpoint = mesh.Positions[i] + vertex_normals[i];

                // Create the segment.
                AddSegment(normals, mesh.Positions[i], endpoint, thickness);
            }

            return normals;
        }

        // Return a MeshGeometry3D representing this mesh's triangle normals.
        public static MeshGeometry3D ToTriangleNormals(this MeshGeometry3D mesh,
            double length, double thickness)
        {
            // Make a mesh to hold the normals.
            MeshGeometry3D normals = new MeshGeometry3D();

            // Loop through the mesh's triangles.
            for (int triangle = 0; triangle < mesh.TriangleIndices.Count; triangle += 3)
            {
                // Get the triangle's vertices.
                Point3D point1 = mesh.Positions[mesh.TriangleIndices[triangle]];
                Point3D point2 = mesh.Positions[mesh.TriangleIndices[triangle + 1]];
                Point3D point3 = mesh.Positions[mesh.TriangleIndices[triangle + 2]];

                // Make the triangle's normal
                AddTriangleNormal(mesh, normals,
                    point1, point2, point3, length, thickness);
            }

            return normals;
        }

        // Add a segment representing the triangle's normal to the normals mesh.
        private static void AddTriangleNormal(MeshGeometry3D mesh,
            MeshGeometry3D normals, Point3D point1, Point3D point2, Point3D point3,
            double length, double thickness)
        {
            // Get the triangle's normal.
            Vector3D n = FindTriangleNormal(point1, point2, point3);

            // Set the length.
            n = ScaleVector(n, length);

            // Find the center of the triangle.
            Point3D endpoint1 = new Point3D(
                (point1.X + point2.X + point3.X) / 3.0,
                (point1.Y + point2.Y + point3.Y) / 3.0,
                (point1.Z + point2.Z + point3.Z) / 3.0);

            // Find the segment's other end point.
            Point3D endpoint2 = endpoint1 + n;

            // Create the segment.
            AddSegment(normals, endpoint1, endpoint2, thickness);
        }

        // Calculate a triangle's normal vector.
        public static Vector3D FindTriangleNormal(Point3D point1, Point3D point2, Point3D point3)
        {
            // Get two edge vectors.
            Vector3D v1 = point2 - point1;
            Vector3D v2 = point3 - point2;

            // Get the cross product.
            Vector3D n = Vector3D.CrossProduct(v1, v2);

            // Normalize.
            n.Normalize();

            return n;
        }

        // Return a MeshGeometry3D representing this mesh's wireframe.
        public static MeshGeometry3D ToWireframe(this MeshGeometry3D mesh, double thickness)
        {
            // Make a dictionary in case triangles share segments
            // so we don't draw the same segment twice.
            Dictionary<int, int> already_drawn = new Dictionary<int, int>();

            // Make a mesh to hold the wireframe.
            MeshGeometry3D wireframe = new MeshGeometry3D();

            // Loop through the mesh's triangles.
            for (int triangle = 0; triangle < mesh.TriangleIndices.Count; triangle += 3)
            {
                // Get the triangle's corner indices.
                int index1 = mesh.TriangleIndices[triangle];
                int index2 = mesh.TriangleIndices[triangle + 1];
                int index3 = mesh.TriangleIndices[triangle + 2];

                // Make the triangle's three segments.
                AddTriangleSegment(mesh, wireframe, already_drawn, index1, index2, thickness);
                AddTriangleSegment(mesh, wireframe, already_drawn, index2, index3, thickness);
                AddTriangleSegment(mesh, wireframe, already_drawn, index3, index1, thickness);
            }

            return wireframe;
        }

        // Add the triangle's three segments to the wireframe mesh.
        private static void AddTriangleSegment(MeshGeometry3D mesh,
            MeshGeometry3D wireframe, Dictionary<int, int> already_drawn,
            int index1, int index2, double thickness)
        {
            // Get a unique ID for a segment connecting the two points.
            if (index1 > index2)
            {
                int temp = index1;
                index1 = index2;
                index2 = temp;
            }
            int segment_id = index1 * mesh.Positions.Count + index2;

            // If we've already added this segment for
            // another triangle, do nothing.
            if (already_drawn.ContainsKey(segment_id)) return;
            already_drawn.Add(segment_id, segment_id);

            // Create the segment.
            AddSegment(wireframe, mesh.Positions[index1], mesh.Positions[index2], thickness);
        }

        // Add a triangle to the indicated mesh.
        // Do not reuse points so triangles don't share normals.
        private static void AddTriangle(MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            mesh.Positions.Add(point1);
            mesh.Positions.Add(point2);
            mesh.Positions.Add(point3);

            // Create the triangle.
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1);
        }

        // Make a thin rectangular prism between the two points.
        // If extend is true, extend the segment by half the
        // thickness so segments with the same end points meet nicely.
        // If up is missing, create a perpendicular vector to use.
        public static void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, double thickness, bool extend)
        {
            // Find an up vector that is not colinear with the segment.
            // Start with a vector parallel to the Y axis.
            Vector3D up = new Vector3D(0, 1, 0);

            // If the segment and up vector point in more or less the
            // same direction, use an up vector parallel to the X axis.
            Vector3D segment = point2 - point1;
            segment.Normalize();
            if (Math.Abs(Vector3D.DotProduct(up, segment)) > 0.9)
                up = new Vector3D(1, 0, 0);

            // Add the segment.
            AddSegment(mesh, point1, point2, up, thickness, extend);
        }
        public static void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, double thickness)
        {
            AddSegment(mesh, point1, point2, thickness, false);
        }
        public static void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Vector3D up, double thickness)
        {
            AddSegment(mesh, point1, point2, up, thickness, false);
        }
        public static void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Vector3D up, double thickness,
            bool extend)
        {
            // Get the segment's vector.
            Vector3D v = point2 - point1;

            if (extend)
            {
                // Increase the segment's length on both ends by thickness / 2.
                Vector3D n = ScaleVector(v, thickness / 2.0);
                point1 -= n;
                point2 += n;
            }

            // Get the scaled up vector.
            Vector3D n1 = ScaleVector(up, thickness / 2.0);

            // Get another scaled perpendicular vector.
            Vector3D n2 = Vector3D.CrossProduct(v, n1);
            n2 = ScaleVector(n2, thickness / 2.0);

            // Make a skinny box.
            // p1pm means point1 PLUS n1 MINUS n2.
            Point3D p1pp = point1 + n1 + n2;
            Point3D p1mp = point1 - n1 + n2;
            Point3D p1pm = point1 + n1 - n2;
            Point3D p1mm = point1 - n1 - n2;
            Point3D p2pp = point2 + n1 + n2;
            Point3D p2mp = point2 - n1 + n2;
            Point3D p2pm = point2 + n1 - n2;
            Point3D p2mm = point2 - n1 - n2;

            // Sides.
            AddTriangle(mesh, p1pp, p1mp, p2mp);
            AddTriangle(mesh, p1pp, p2mp, p2pp);

            AddTriangle(mesh, p1pp, p2pp, p2pm);
            AddTriangle(mesh, p1pp, p2pm, p1pm);

            AddTriangle(mesh, p1pm, p2pm, p2mm);
            AddTriangle(mesh, p1pm, p2mm, p1mm);

            AddTriangle(mesh, p1mm, p2mm, p2mp);
            AddTriangle(mesh, p1mm, p2mp, p1mp);

            // Ends.
            AddTriangle(mesh, p1pp, p1pm, p1mm);
            AddTriangle(mesh, p1pp, p1mm, p1mp);

            AddTriangle(mesh, p2pp, p2mp, p2mm);
            AddTriangle(mesh, p2pp, p2mm, p2pm);
        }

        // Set the vector's length.
        public static Vector3D ScaleVector(Vector3D vector, double length)
        {
            double scale = length / vector.Length;
            return new Vector3D(
                vector.X * scale,
                vector.Y * scale,
                vector.Z * scale);
        }

        // Make an arrow.
        public static void AddArrow(this MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Vector3D up,
            double barb_length)
        {
            // Make the shaft.
            AddSegment(mesh, point1, point2, 0.05, true);

            // Get a unit vector in the direction of the segment.
            Vector3D v = point2 - point1;
            v.Normalize();

            // Get a perpendicular unit vector in the plane of the arrowhead.
            Vector3D perp = Vector3D.CrossProduct(v, up);
            perp.Normalize();

            // Calculate the arrowhead end points.
            Vector3D v1 = ScaleVector(-v + perp, barb_length);
            Vector3D v2 = ScaleVector(-v - perp, barb_length);

            // Draw the arrowhead.
            AddSegment(mesh, point2, point2 + v1, up, 0.05);
            AddSegment(mesh, point2, point2 + v2, up, 0.05);
        }

        // Make an axis with tic marks.
        public static void AddAxis(this MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Vector3D up,
            double tic_diameter, double tic_separation)
        {
            // Make the shaft.
            AddSegment(mesh, point1, point2, 1, true);

            // Get a unit vector in the direction of the segment.
            Vector3D v = point2 - point1;
            double length = v.Length;
            v.Normalize();

            // Find the position of the first tic mark.
            Point3D tic_point1 = point1 + v * (tic_separation - 0.025);

            // Make tic marks.
            int num_tics = (int)(length / tic_separation) - 1;
            for (int i = 0; i < num_tics; i++)
            {
                Point3D tic_point2 = tic_point1 + v * 0.05;
                AddSegment(mesh, tic_point1, tic_point2, tic_diameter);
                tic_point1 += v * tic_separation;
            }
        }
    }
}
