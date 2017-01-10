using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

// 어셈블리의 일반 정보는 다음 특성 집합을 통해 제어됩니다.
// 어셈블리와 관련된 정보를 수정하려면
// 이 특성 값을 변경하십시오.
[assembly: AssemblyTitle("Xceed.Wpf.AvalonDock.Themes.DarkConcept")]
[assembly: AssemblyDescription("This assembly implements the DataConcept Theme for the AvalonDock layout system")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Bucketplay Inc.")]
[assembly: AssemblyProduct("Xceed.Wpf.AvalonDock.Themes.DarkConcept")]
[assembly: AssemblyCopyright("Copyright (c) Buckeyplay Inc.  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible을 false로 설정하면 이 어셈블리의 형식이 COM 구성 요소에 
// 표시되지 않습니다.  COM에서 이 어셈블리의 형식에 액세스하려면 
// 해당 형식에 대해 ComVisible 특성을 true로 설정하십시오.
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
// 이 프로젝트가 COM에 노출되는 경우 다음 GUID는 typelib의 ID를 나타냅니다.
[assembly: Guid("ab0e82a5-f491-4f31-b950-4d2d42743fe5")]

// 어셈블리의 버전 정보는 다음 네 가지 값으로 구성됩니다.
//
//      주 버전
//      부 버전 
//      빌드 번호
//      수정 버전
//
// 모든 값을 지정하거나 아래와 같이 '*'를 사용하여 빌드 번호 및 수정 버전이 자동으로
// 지정되도록 할 수 있습니다.
// [assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ThemeInfo(
		ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
	//(used if a resource is not found in the page, 
	// or application resource dictionaries)
		ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
	//(used if a resource is not found in the page, 
	// app, or any theme specific resource dictionaries)
)]


[assembly: XmlnsDefinition("http://schemas.xceed.com/wpf/xaml/avalondock", "Xceed.Wpf.AvalonDock.Themes")]