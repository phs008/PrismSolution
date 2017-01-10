using System;
using System.Collections.Generic;
using System.Linq;
using MVRWrapper;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;
using VRCAT.Infrastructure.DragDrop;
using VRCAT.DataModel;
using System.Collections.ObjectModel;
using VRCAT.Infrastructure;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel.Event;
using System.Windows.Input;
using WPFXCommand;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace VRCAT.InspectorModule
{
    public abstract class PropertyViewModel : BindableBase , IDisposable
    {
        ICommand _EnterkeyBinding;
        public ICommand EnterkeyBinding
        {
            get
            {
                if (_EnterkeyBinding == null)
                    _EnterkeyBinding = new RelayCommand(new Action<object>(delegate (object o)
                    {

                    }));
                return _EnterkeyBinding;
            }
        }
        private readonly string _ParamLabel;
        internal SubscriptionToken _EngineEventSubscripeToken = null;
        private readonly MContainer _ParentContainer = null;
        private readonly MResourceMaterial _ParentMtl = null;
        private readonly MResourceAnimation _ParentAni = null;
        private readonly MEngineConfig _ParentConfig = null;
        private readonly MResTexture _ParentResTexture = null;
        public object _LastValue;
        public string ParamLabel
        {
            get { return _ParamLabel; }
        } 
        internal readonly MProperty _ParamModel;
        public PropertyViewModel(MProperty param,object parentObj)
        {
            this._ParamLabel = param.Name;
            this._ParamModel = param;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(d =>
            {
                if (d.Equals("InspectorUpdateEvent"))
                    OnpropertyChangeUpdate();
            });
            if (parentObj is MContainer)
                _ParentContainer = (MContainer)parentObj;
            else if (parentObj is MResourceMaterial)
                _ParentMtl = (MResourceMaterial)parentObj;
            else if (parentObj is MResourceAnimation)
                _ParentAni = (MResourceAnimation)parentObj;
            else if (parentObj is MEngineConfig)
                _ParentConfig = (MEngineConfig)parentObj;
            else if(parentObj is MResTexture)
                _ParentResTexture = (MResTexture)parentObj;
        }
        public void OnSave()
        {
            if (_ParentMtl != null)
                _ParentMtl.SaveToFile();
            else if (_ParentConfig != null)
                _ParentConfig.SaveConfig();
            else if (_ParentResTexture != null)
            { }
        }
        virtual public void OnpropertyChangeUpdate()
        {
            OnPropertyChanged("Value");
        }

        virtual public void Dispose()
        {
            if (_EngineEventSubscripeToken != null)
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Unsubscribe(_EngineEventSubscripeToken);
        }
    }
    public class VRDefaultVM : PropertyViewModel
    {
        public VRDefaultVM(MProperty param,object Parent)
            : base(param,Parent)
        { }
        public Object Value
        {
            get { return _ParamModel.Value; }
            set { _ParamModel.Value = value; OnPropertyChanged("Value"); OnSave(); }
        }
    }
    public class VRBoolVM : PropertyViewModel
    {
        public VRBoolVM(MProperty param, object Parent = null)
            : base(param, Parent)
        { }
        public bool Value
        {
            get { return (bool)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }
    }
    public class VRStringVM : PropertyViewModel
    {
        public VRStringVM(MProperty param,object Parent = null)
            : base(param,Parent) { }

        
        public string Value
        {
            get { return (string)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }
    }
    public class VRIntVM : PropertyViewModel
    {
        public VRIntVM(MProperty param,object Parent = null)
            : base(param,Parent) { }
        public int Value
        {
            get { return (int)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }
    }
    public class VRFloatVM : PropertyViewModel
    {
        public VRFloatVM(MProperty param,object Parent =  null)
            : base(param,Parent) { }
        public float Value
        {
            get { return (float)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }
    }
    public class VRDoubleVM : PropertyViewModel
    {
        public VRDoubleVM(MProperty param,object Parent = null)
            : base(param,Parent) { }
        public double Value
        {
            get { return (float)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }
    }
    public class VRRangeVM : PropertyViewModel
    {
        public VRRangeVM(MProperty param,object Parent = null)
            : base(param,Parent) { }
        public float Max
        {
            get { return ((MRange)_ParamModel.Value).max; }
            set { ((MRange)_ParamModel.Value).max = value; OnSave(); }
        }
        public float Min
        {
            get { return ((MRange)_ParamModel.Value).min; }
            set { ((MRange)_ParamModel.Value).min = value; OnSave(); }
        }
        public float Value
        {
            get { return ((MRange)_ParamModel.Value).val; }
            set { ((MRange)_ParamModel.Value).val = value; OnSave(); }
        }
    }

    public class VRVector2VM : PropertyViewModel
    {
        public VRVector2VM(MProperty param,object Parent = null)
            : base(param,Parent) { }
        public float X
        {
            get { return ((MVector2)_ParamModel.Value).X; }
            set
            {
                ((MVector2)_ParamModel.Value).X = value;
                OnSave();
                //OnPropertyChanged("X");
            }
        }
        public float Y
        {
            get { return ((MVector2)_ParamModel.Value).Y; }
            set
            {
                ((MVector2)_ParamModel.Value).Y = value;
                OnSave();
                //OnPropertyChanged("Y");
            }
        }
        public override void OnpropertyChangeUpdate()
        {
            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }
    }
    public class VRVector3VM : PropertyViewModel
    {
        MContainer _ParentContainer;
        bool HasContiguousTransformList = false;
        int PropertyType = -1;
        
        public VRVector3VM(MProperty param,object Parent = null)
            : base(param,Parent)
        {
            if (Parent != null && Parent is MContainer)
            {
                _ParentContainer = (MContainer)Parent;
                if(_ParentContainer.ContiguousContainerList != null && _ParentContainer.ContiguousContainerList.Count > 1)
                {
                    HasContiguousTransformList = true;
                    float increaseX = 0.0f, increaseY = 0.0f, increaseZ = 0.0f;
                    foreach(MContainer c in _ParentContainer.ContiguousContainerList)
                    {
                        if (c.Transform != null)
                        {
                            increaseX += c.Transform.Position.X;
                            increaseY += c.Transform.Position.Y;
                            increaseZ += c.Transform.Position.Z;
                            if (param.Name.Equals("Position"))
                                PropertyType = 1;
                            else if (param.Name.Equals("Scale"))
                                PropertyType = 2;
                        }
                    }
                    increaseX /= _ParentContainer.ContiguousContainerList.Count;
                    increaseY /= _ParentContainer.ContiguousContainerList.Count;
                    increaseZ /= _ParentContainer.ContiguousContainerList.Count;

                    _ParentContainer.Transform.Position.X = increaseX;
                    _ParentContainer.Transform.Position.Y = increaseY;
                    _ParentContainer.Transform.Position.Z = increaseZ;
                }
            }
            /// FrameRate 에 따른 Property Update 메세지는 펌핑이 너무 과함에 따라 Vector3 만 변경하는걸로 추가한 메세지
            _EngineEventSubscripeToken = Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Subscribe(o =>
            {
                if (o.eventArg == EngineEventArg.Vector3Refresh)
                {
                    OnPropertyChanged("X");
                    OnPropertyChanged("Y");
                    OnPropertyChanged("Z");
                    if (HasContiguousTransformList)
                    {
                        foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                        {
                            if (t.Transform != null)
                            {
                                if (PropertyType == 1 && VRWorld.Instance.GizmoType == 0)
                                {
                                    t.Transform.Position.X = X;
                                    t.Transform.Position.Y = Y;
                                    t.Transform.Position.Z = Z;
                                }
                                else if (PropertyType == 2 && VRWorld.Instance.GizmoType == 1)
                                {
                                    t.Transform.Scale.X = X;
                                    t.Transform.Scale.Y = Y;
                                    t.Transform.Scale.Z = Z;
                                }
                            }
                        }
                    }
                }
            });
        }
        public float X
        {
            get { return ((MVector3)_ParamModel.Value).X; }
            set
            {
                StateManager.Instance.ChangeSet(new UndoCommand
                    (() =>
                    {
                        _LastValue = ((MVector3)_ParamModel.Value).X;
                        ((MVector3)_ParamModel.Value).X = value;
                        if (HasContiguousTransformList)
                        {
                            foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                            {
                                if (PropertyType == 1)
                                {
                                    t.Transform.Position.X = value;
                                    //t.Transform.UpdateTransform();
                                }
                                else if (PropertyType == 2)
                                {
                                    t.Transform.Scale.X = value;
                                    //t.Transform.UpdateTransform();
                                }
                            }
                        }
                        OnSave();
                        ///OnPropertyChanged("X");
                    },
                    () =>
                    {
                        ((MVector3)_ParamModel.Value).X = (float)_LastValue;
                        if (HasContiguousTransformList)
                        {
                            foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                            {
                                if (PropertyType == 1)
                                {
                                    t.Transform.Position.X = value;
                                }
                                else if (PropertyType == 2)
                                {
                                    t.Transform.Scale.X = value;
                                }
                            }
                        }
                        OnSave();
                        ///OnPropertyChanged("X");
                    }
                    ));
                //((MVector3)_ParamModel.Value).X = value;
                //if (HasContiguousTransformList)
                //{
                //    foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                //    {
                //        if (PropertyType == 1)
                //        {
                //            t.Transform.Position.X = value;
                //            //t.Transform.UpdateTransform();
                //        }
                //        else if (PropertyType == 2)
                //        {
                //            t.Transform.Scale.X = value;
                //            //t.Transform.UpdateTransform();
                //        }
                //    }
                //}
                ///OnSave();
            }
        }
        public float Y
        {
            get { return ((MVector3)_ParamModel.Value).Y; }
            set
            {
                ((MVector3)_ParamModel.Value).Y = value;
                ///MGizmoConnector.GetInstance().SetGizmoPosition((MVector3)_ParamModel.Value);
                //OnPropertyChanged("Y");  
                if (HasContiguousTransformList)
                {
                    foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                    {
                        if (PropertyType == 1)
                        {
                            t.Transform.Position.Y = value;
                            t.Transform.UpdateTransform();
                        }
                        else if (PropertyType == 2)
                        {
                            t.Transform.Scale.Y = value;
                            t.Transform.UpdateTransform();
                        }
                    }
                }
                OnSave();
            }
        }
        public float Z
        {
            get { return ((MVector3)_ParamModel.Value).Z; }
            set
            {
                ((MVector3)_ParamModel.Value).Z = value;
                //MGizmoConnector.GetInstance().SetGizmoPosition((MVector3)_ParamModel.Value);
                //OnPropertyChanged("Z");
                if (HasContiguousTransformList)
                {
                    foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                    {
                        if (PropertyType == 1)
                        {
                            t.Transform.Position.Z = value;
                            t.Transform.UpdateTransform();
                        }
                        else if (PropertyType == 2)
                        {
                            t.Transform.Scale.Z = value;
                            t.Transform.UpdateTransform();
                        }
                    }
                }
                OnSave();
            }
        }
        public override void OnpropertyChangeUpdate()
        {
            OnPropertyChanged("X");
            OnPropertyChanged("Y");
            OnPropertyChanged("Z");
        }
    }
    public class VRVector4VM : PropertyViewModel
    {
        public VRVector4VM(MProperty param,object Parent = null)
            : base(param,Parent) { }
        public float X
        {
            get { return ((MVector4)_ParamModel.Value).X; }
            set
            {
                ((MVector4)_ParamModel.Value).X = value;
                OnSave();
                //OnPropertyChanged("X");
            }
        }
        public float Y
        {
            get { return ((MVector4)_ParamModel.Value).Y; }
            set
            {
                ((MVector4)_ParamModel.Value).Y = value;
                OnSave();
                //OnPropertyChanged("Y");  
            }
        }
        public float Z
        {
            get { return ((MVector4)_ParamModel.Value).Z; }
            set
            {
                ((MVector4)_ParamModel.Value).Z = value;
                OnSave();
                //OnPropertyChanged("Z");
            }
        }
        public float W
        {
            get { return ((MVector4)_ParamModel.Value).W; }
            set
            {
                ((MVector4)_ParamModel.Value).W = value;
                OnSave();
                //OnPropertyChanged("W");
            }
        }
    }
    public class VRQuaternionVM : PropertyViewModel
    {
        MContainer _ParentContainer;
        bool HasContiguousTransformList = false;
        public VRQuaternionVM(MProperty param,object Parent = null)
            : base(param,Parent)
        {
            if (Parent != null && Parent is MContainer)
            {
                _ParentContainer = (MContainer)Parent;
                if (_ParentContainer.ContiguousContainerList != null && _ParentContainer.ContiguousContainerList.Count > 1)
                {
                    HasContiguousTransformList = true;
                    float increaseX = 0.0f, increaseY = 0.0f, increaseZ = 0.0f;
                    foreach (MContainer c in _ParentContainer.ContiguousContainerList)
                    {
                        if (c.Transform != null)
                        {
                            increaseX += c.Transform.Position.X;
                            increaseY += c.Transform.Position.Y;
                            increaseZ += c.Transform.Position.Z;
                        }
                    }
                    increaseX /= _ParentContainer.ContiguousContainerList.Count;
                    increaseY /= _ParentContainer.ContiguousContainerList.Count;
                    increaseZ /= _ParentContainer.ContiguousContainerList.Count;
                }
            }
            _EngineEventSubscripeToken = Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<EngineEvent>>().Subscribe(o =>
            {
                if (o.eventArg == EngineEventArg.Vector3Refresh && VRWorld.Instance.GizmoType == 2)
                {
                    OnPropertyChanged("X");
                    OnPropertyChanged("Y");
                    OnPropertyChanged("Z");
                    if (HasContiguousTransformList)
                    {
                        foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                        {
                            if (t.Transform != null)
                            {
                                t.Transform.Rotation.X = X;
                                t.Transform.Rotation.Y = Y;
                                t.Transform.Rotation.Z = Z;
                            }
                        }
                    }
                }
            });
        }
        public float X
        {
            get { return ((MQuaternion)_ParamModel.Value).X; }
            set
            {
                ((MQuaternion)_ParamModel.Value).X = value;
                if (HasContiguousTransformList)
                {
                    foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                    {
                        t.Transform.Rotation.X = value;
                    }
                }
                OnSave();
                //OnPropertyChanged("X");
            }
        }
        public float Y
        {
            get { return ((MQuaternion)_ParamModel.Value).Y; }
            set
            {
                ((MQuaternion)_ParamModel.Value).Y = value;
                if (HasContiguousTransformList)
                {
                    foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                    {
                        t.Transform.Rotation.Y = value;
                    }
                }
                OnSave();
                //OnPropertyChanged("Y");
            }
        }
        public float Z
        {
            get { return ((MQuaternion)_ParamModel.Value).Z; }
            set
            {
                ((MQuaternion)_ParamModel.Value).Z = value;
                if (HasContiguousTransformList)
                {
                    foreach (MContainer t in _ParentContainer.ContiguousContainerList)
                    {
                        t.Transform.Rotation.Z = value;
                    }
                }
                OnSave();
                //OnPropertyChanged("Z");
            }
        }

        public override void OnpropertyChangeUpdate()
        {
            //base.OnpropertyChangeUpdate();
            OnPropertyChanged("X");
            OnPropertyChanged("Y");
            OnPropertyChanged("Z");
        }

    }
    public class VRColorVM : PropertyViewModel
    {
        private string lastHexCode = "#000000";
        private MColor color;
        public VRColorVM(MProperty param,object Parent = null)
            : base(param,Parent)
        {
            color = (MColor)param.Value;
        }
        private string HexFromRGB(float r, float g, float b)
        {
            int R = FloatColorToChangeIntColor(r);
            int G = FloatColorToChangeIntColor(g);
            int B = FloatColorToChangeIntColor(b);
            string HexVal = "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
            return HexVal;
        }
        private Color _SelectedColor;
        public Color SelectedColor
        {
            get
            {
                string HexCode = HexFromRGB(color.R, color.G, color.B);
                Color c = (Color)ColorConverter.ConvertFromString(HexCode);
                return c;
            }
            set
            {
                int R = Convert.ToInt16(value.R.ToString());
                int G = Convert.ToInt16(value.G.ToString());
                int B = Convert.ToInt16(value.B.ToString());
                color.R = IntColorToChangeFloatColor(R);
                color.G = IntColorToChangeFloatColor(G);
                color.B = IntColorToChangeFloatColor(B);
                Console.WriteLine("Change Color R : " + color.R + " G: " + color.G + " B: " + color.B);
                OnSave();
                //SelectedColor = value;
            }
        }
        public float Alpha
        {
            get
            {
                return color.A;
            }
            set
            {
                color.A = value;
                OnPropertyChanged("Alpha");
                OnSave();
            }
        }

        /// <summary>
        /// Float 칼라 -> int 변환
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int FloatColorToChangeIntColor(float value)
        {
            Double b = Math.Floor(value == 1.0 ? 255 : value * 256.0);
            /// 밑의 코드는 필요없음
            //Double b2 = Math.Max(0.0, Math.Min(1.0, b));
            //b = Math.Floor(b2 == 1.0 ? 255 : b2 * 256.0);
            return (int)b;
        }
        /// <summary>
        /// int 칼라 -> float 으로 변환
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        float IntColorToChangeFloatColor(int value)
        {
            float returnVal = value / 255f;
            return returnVal;
        }
    }
    public class VRContainerObjectVM : PropertyViewModel , IDropTarget
    {
        public DelegateCommand<RoutedEventArgs> ContainerReset { get; private set; }
        public VRContainerObjectVM(MProperty property,object Parent)
            : base(property,Parent)
        {
            ContainerReset = new DelegateCommand<RoutedEventArgs>(param =>
            {
                Value = (long)0;
            });
        }
        public object Value
        {
            get
            {
                return _ParamModel.Value;
            }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is NodeVM)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = System.Windows.DragDropEffects.Copy;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is NodeVM)
            {
                MContainer dropItem = (MContainer)((NodeVM)dropInfo.Data).NodeObject;
                Int64 DropItemUID = dropItem.UID;
                Value = DropItemUID;
            }
        }
    }
    public class VREnumVM : PropertyViewModel
    {
        public class VREnumData
        {
            public VREnumData(string label,int val)
            {
                Label = label;
                ID = val;
            }
            public string Label { get; set; }
            public int ID { get; set; }
        }
        
        public VREnumVM(MProperty param,object Parent = null)
            :base(param,Parent)
        {
            foreach (object[] o in param.GetEnumerator())
            {
                EnumBindingSource.Add(new VREnumData((string)o[0], (int)o[1]));
                //Enums.Add((string)o[0]);
            }
        }
        private List<VREnumData> _EnumBindingSource;
        public List<VREnumData> EnumBindingSource
        {
            get
            {
                if (_EnumBindingSource == null)
                    _EnumBindingSource = new List<VREnumData>();
                return _EnumBindingSource;
            }
            set { _EnumBindingSource = value; }
        }
        //private List<string> _Enums;
        //public List<string> Enums
        //{
        //    get { if (null == _Enums) _Enums = new List<string>(); return _Enums; }
        //    set { _Enums = value; }
        //}
        public int Value
        {
            get { return (int)_ParamModel.Value; }
            set
            {
                if (value != null)
                {
                    _ParamModel.Value = value;
                    OnPropertyChanged("Value");
                    OnSave();
                }
            }
        }

        
    }
    public class VRAnimationVM : PropertyViewModel
    {
        readonly MContainer _ParentObject;
        public DelegateCommand<RoutedEventArgs> AnimationRemove { get; private set; }
        public VRAnimationVM(MProperty param, object ParentObj)
            : base(param,ParentObj)
        {
            if (ParentObj is MContainer)
                _ParentObject = (MContainer)ParentObj;
            AnimationRemove = new DelegateCommand<RoutedEventArgs>(p =>
            {
                RemoveAnimation();
            });
        }
        public string Value
        {
            get { return (string)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }
        private void RemoveAnimation()
        {
            if(_ParentObject != null)
            {
                MFbxComponent f = _ParentObject.GetComponent<MFbxComponent>(ComponentEnum.Fbx);
                string[] splitValue = Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitValue.Length > 0)
                {
                    f.RemoveAnimation(splitValue.Last());
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<InspectorViewRefreshEvent>>().Publish(new InspectorViewRefreshEvent() { RefreshViewTargetObj = _ParentObject });
                }
            }
        }
    }

    public class VRFilePathVM : PropertyViewModel, IDropTarget
    {
        VRFilePathVM _ScriptPrpertyVM;
        public VRFilePathVM(MProperty param,object Parent = null)
            : base(param,Parent)
        { }
        public string Value
        {
            get { return (string)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                OnPropertyChanged("Value");
                OnSave();
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = System.Windows.DragDropEffects.Copy;
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is FileModel)
            {
                string path = ((FileModel)dropInfo.Data).FullPath;
                path = path.Replace(@"\", "/");
                Value = path;
            }
        }
    }
    public class VRTextureFilePathVM : PropertyViewModel, IDropTarget
    {
        public DelegateCommand<RoutedEventArgs> ShowTextureImageView { get; private set; }
        public ObservableCollection<FileModel> TextureImages
        {
            get { return VRWorld.Instance.ImageFileCollection; }
        }

        public VRTextureFilePathVM(MProperty param,object ParentObj)
            : base(param,ParentObj)
        {
            ShowTextureImageView = new DelegateCommand<RoutedEventArgs>(delegate (RoutedEventArgs e)
            {
                ShowTextureImage textureContol = new ShowTextureImage();
                textureContol.DataContext = this;
                textureContol.Show();
            });
        }
        public string Value
        {
            get { return (string)_ParamModel.Value; }
            set
            {
                _ParamModel.Value = value;
                //MPropertyGroup pGroup = base._ParamModel.ParentPropertyGroup;
                //if (parentMtl != null)
                //    parentMtl.SaveToFile();
                OnPropertyChanged("Value");
                OnSave();
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = System.Windows.DragDropEffects.Copy;
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is FileModel)
            {
                string path = ((FileModel)dropInfo.Data).FullPath;
                Value = path;
            }
        }
    }
    //public class VRScriptFilePathVM : PropertyViewModel, IDropTarget
    //{
    //    MContainer _OwnerTransformGroup;
    //    public VRScriptFilePathVM(MProperty param, object Parent = null)
    //        : base(param,Parent)
    //    {
    //        _OwnerTransformGroup = OwnerTransformGroup;
    //    }
    //    public string Value
    //    {
    //        get
    //        {
    //            if(!string.IsNullOrEmpty((string)_ParamModel.Value))
    //            {
    //                MPropertyGroup pGroup = this._ParamModel.GetTypeScriptPropertyGroup();
    //                PropertyGroupViewModel groupVM = new PropertyGroupViewModel(pGroup, _OwnerTransformGroup);
    //                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ScriptEvent>>().Publish(new ScriptEvent() { val = groupVM });
    //            }
    //            return (string)_ParamModel.Value;
    //        }
    //        set
    //        {
    //            _ParamModel.Value = value;
    //            //OnPropertyChanged("Value");
    //            MPropertyGroup pGroup = this._ParamModel.GetTypeScriptPropertyGroup();
    //            if (pGroup != null)
    //            {
    //                PropertyGroupViewModel groupVM = new PropertyGroupViewModel(pGroup, _OwnerTransformGroup);
    //                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ScriptEvent>>().Publish(new ScriptEvent() { val = groupVM });
    //            }
    //        }
    //    }

    //    public void DragOver(IDropInfo dropInfo)
    //    {
    //        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
    //        dropInfo.Effects = System.Windows.DragDropEffects.Copy;
    //    }

    //    public void Drop(IDropInfo dropInfo)
    //    {
    //        if (dropInfo.Data is FileModel)
    //        {
    //            string path = ((FileModel)dropInfo.Data).FullPath;
    //            Value = path;
    //        }
    //    }
    //}
}
