@ECHO OFF

SETLOCAL
SETLOCAL ENABLEDELAYEDEXPANSION

SET DebugMode=1


:: 호출한 위치 저장
SET PrevDir=%CD%

:: 작업 디렉토리 변경
CD /D %~dp0


:: 환경 변수 설정
SET BinDir=%~dp0
SET ProjectDir=%~dpnx2\
SET OutputDir=%ProjectDir%Temp\Script\obj\
SET ResultDir=%ProjectDir%Script\

SET ESSourceDir=ESLibrary\source\
SET ESLibraryDir=ESLibrary\lib\
SET PCHDir=ESLibrary\pch\
SET ToolDir=Tool\

SET ExitCode=0

SET PATH=%PATH%;%ToolDir%MinGW\Bin


:: 프로그램 설정
SET Preprocessor=Preprocessor.exe
SET ESC=esc.exe
SET CodeGenerator=CodeGenerator.exe
SET ESLibraryGenerator=ESLibraryGenerator.exe
SET CC=g++
SET FileTimeGetter=GetFileTime.exe


:: 파일명 설정
SET ESList=%ProjectDir%Temp\Script\eslist


:: Preprocessor 실행
FOR /F "tokens=* delims=" %%l IN (%ESList%) DO (
	FOR /F "tokens=1" %%f IN ("%ProjectDir%%%l") DO (
		SET CS_FileDirectory=%%~dpf
		SET Preprocessor_FileName=%%~nf_ESC.cs

		SET CS_OutputFilePath=%OutputDir%%%l
		SET CS_OutputDirectory=
		FOR /F "tokens=1" %%f IN ("!CS_OutputFilePath!") DO (
			SET CS_OutputDirectory=%%~dpf
		)

		IF NOT %DebugMode% == 0 (
			ECHO.
			ECHO Preprocessing %%l...
		)

		:: 경로 생성
		IF NOT EXIST !CS_OutputDirectory! (
			MKDIR !CS_OutputDirectory! 2> ignore
		)

		FOR /F %%o in ('%BinDir%%ToolDir%%FileTimeGetter% %%f 2') DO SET FileTime01=%%o
		FOR /F %%o in ('%BinDir%%ToolDir%%FileTimeGetter% !CS_OutputFilePath! 2') DO SET FileTime02=%%o

		IF !FileTime02! GEQ !FileTime01! (
			IF NOT %DebugMode% == 0 (
				ECHO     Skipped...
			)
		) ELSE (
			:: Preprocessing
			IF NOT %DebugMode% == 0 (
				ECHO %ToolDir%%Preprocessor% %%f
			)
			%ToolDir%%Preprocessor% %%f

			IF NOT %ErrorLevel% == 0 (
				SET ExitCode=%ErrorLevel%
				GOTO :EXIT
			)

			:: Move to %OutputDir% Directory
			IF NOT %DebugMode% == 0 (
				ECHO MOVE !CS_FileDirectory!!Preprocessor_FileName! !CS_OutputFilePath!
				MOVE !CS_FileDirectory!!Preprocessor_FileName! !CS_OutputFilePath!
			) ELSE (
				MOVE !CS_FileDirectory!!Preprocessor_FileName! !CS_OutputFilePath! > ignore
			)
		)
	)
)


:: E# 컴파일러 실행
SET CurrentDir=%CD%\
CD %ToolDir%

SET CS_FilePathList=
SET CS_FileNameList=
SET PCH_FilePathList=

:: CS 파일 모음
FOR /F "tokens=* delims=" %%l IN (%ESList%) DO (
	FOR /F "tokens=1" %%f IN ("%%l") DO (
		SET CS_FilePathList=%OutputDir%%%f !CS_FilePathList!
		SET CS_FileNameList=%%~nxf !CS_FileNameList!
	)
)

:: PCH 파일 모음
FOR %%f IN (%BinDir%%PCHDIR%*.csi) DO (
	CALL :AddPCHFileName %%f
)

GOTO :EndPCHFilesGathering

:AddPCHFileName [%1 - param]
SET PCH_FilePathList=%1 %PCH_FilePathList%
GOTO :EOF

:EndPCHFilesGathering

IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO Compiling %CS_FileNameList%...
	ECHO %ESC% -c %CS_FilePathList% %PCH_FilePathList%
)
%ESC% -c %CS_FilePathList% %PCH_FilePathList%

IF NOT %ErrorLevel% == 0 (
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)

CD %CurrentDir%


SET ObjectFiles=


:: C++ 코드 생성
FOR /F "tokens=* delims=" %%l IN (%ESList%) DO (
	FOR /F "tokens=1" %%f IN ("%%l") DO (
		SET CS_OutputFilePath=%OutputDir%%%l
		SET AST_OutputDirectory=
		FOR /F "tokens=1" %%f IN ("!CS_OutputFilePath!") DO (
			SET AST_OutputDirectory=%%~dpf
		)

		SET AST_FilePath=!AST_OutputDirectory!%%~nf.ast
		SET CSI_FilePath=!AST_OutputDirectory!%%~nf.csi
		SET CPP_SrcFileName=%%~nf.cpp
		SET CPP_ObjFileName=%%~nf.o

		IF NOT %DebugMode% == 0 (
			ECHO.
			ECHO Generating C++ code for %%f...
		)

		FOR /F %%o in ('%BinDir%%ToolDir%%FileTimeGetter% !AST_FilePath! 2') DO SET FileTime01=%%o
		FOR /F %%o in ('%BinDir%%ToolDir%%FileTimeGetter% !AST_OutputDirectory!!CPP_SrcFileName! 2') DO SET FileTime02=%%o

		IF !FileTime02! GEQ !FileTime01! (
			IF NOT %DebugMode% == 0 (
				ECHO     Skipped...
			)
		) ELSE (
			:: .h/.cpp 생성
			IF NOT %DebugMode% == 0 (
				ECHO %ToolDir%%CodeGenerator% !AST_FilePath! !CSI_FilePath! !AST_OutputDirectory!
			)
			%ToolDir%%CodeGenerator% !AST_FilePath! !CSI_FilePath! !AST_OutputDirectory! %OutputDir%

			:: cpp 파일 컴파일
			IF NOT %DebugMode% == 0 (
				ECHO.
				ECHO Compling !CPP_SrcFileName!...
				ECHO %CC% !AST_OutputDirectory!!CPP_SrcFileName! -c -o !AST_OutputDirectory!!CPP_ObjFileName! -std=gnu++11 -I%ESSourceDir%
				%CC% !AST_OutputDirectory!!CPP_SrcFileName! -c -o !AST_OutputDirectory!!CPP_ObjFileName! -std=gnu++11 -I%ESSourceDir%
			) ELSE (
				%CC% !AST_OutputDirectory!!CPP_SrcFileName! -c -o !AST_OutputDirectory!!CPP_ObjFileName! -std=gnu++11 -I%ESSourceDir% 2> ignore
			)

			IF NOT !ErrorLevel! == 0 (
				IF %DebugMode% == 0 (
					ECHO Interal error
				)
				SET ExitCode=!ErrorLevel!
				GOTO :EXIT
			)

			SET ObjectFiles=!AST_OutputDirectory!!CPP_ObjFileName! !ObjectFiles!
		)
	)
)


:: E# Library 코드 생성
IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO Generating E# Library code...
	ECHO %ToolDir%%ESLibraryGenerator% %ESList% %OutputDir%
)
%ToolDir%%ESLibraryGenerator% %ESList% %OutputDir%

IF NOT %ErrorLevel% == 0 (
	IF %DebugMode% == 0 (
		ECHO Interal error
	)
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)


:: 소스 파일 컴파일

IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO Compling ESharp.cpp...
	ECHO %CC% %ESSourceDir%ESharp.cpp -c -o %OutputDir%ESharp.o -std=gnu++11
	%CC% %ESSourceDir%ESharp.cpp -c -o %OutputDir%ESharp.o -std=gnu++11
) ELSE (
	%CC% %ESSourceDir%ESharp.cpp -c -o %OutputDir%ESharp.o -std=gnu++11 2> ignore
)

IF NOT %ErrorLevel% == 0 (
	IF %DebugMode% == 0 (
		ECHO Interal error
	)
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)

SET ObjectFiles=%OutputDir%ESharp.o %ObjectFiles%


IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO Compling ESDllInterfacePreGen.cpp...
	ECHO %CC% %ESSourceDir%ESDllInterfacePreGen.cpp -c -o %OutputDir%ESDllInterfacePreGen.o -std=gnu++11
	%CC% %ESSourceDir%ESDllInterfacePreGen.cpp -c -o %OutputDir%ESDllInterfacePreGen.o -std=gnu++11
) ELSE (
	%CC% %ESSourceDir%ESDllInterfacePreGen.cpp -c -o %OutputDir%ESDllInterfacePreGen.o -std=gnu++11 2> ignore
)

IF NOT %ErrorLevel% == 0 (
	IF %DebugMode% == 0 (
		ECHO Interal error
	)
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)

SET ObjectFiles=%OutputDir%ESDllInterfacePreGen.o %ObjectFiles%


IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO Compling ESDllInterface.cpp...
	ECHO %CC% %OutputDir%ESDllInterface.cpp -c -o %OutputDir%ESDllInterface.o -std=gnu++11 -I%ESSourceDir%
	%CC% %OutputDir%ESDllInterface.cpp -c -o %OutputDir%ESDllInterface.o -std=gnu++11 -I%ESSourceDir%
) ELSE (
	%CC% %OutputDir%ESDllInterface.cpp -c -o %OutputDir%ESDllInterface.o -std=gnu++11 -I%ESSourceDir% 2> ignore
)

IF NOT %ErrorLevel% == 0 (
	IF %DebugMode% == 0 (
		ECHO Interal error
	)
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)

SET ObjectFiles=%OutputDir%ESDllInterface.o %ObjectFiles%


IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO Compiling Engine.cpp...
	ECHO %CC% %ESSourceDir%Engine.cpp -c -o %OutputDir%Engine.o -std=gnu++11
	%CC% %ESSourceDir%Engine.cpp -c -o %OutputDir%Engine.o -std=gnu++11
) ELSE (
	%CC% %ESSourceDir%Engine.cpp -c -o %OutputDir%Engine.o -std=gnu++11 2> ignore
)

IF NOT %ErrorLevel% == 0 (
	IF %DebugMode% == 0 (
		ECHO Interal error
	)
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)

SET ObjectFiles=%OutputDir%Engine.o %ObjectFiles%


:: Dll 파일 생성

IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO %CC% -shared -o %ResultDir%Project.dll -Wl,--out-implib,%ResultDir%Project.lib %ObjectFiles% -L%ESLibraryDir% -lgc
	%CC% -shared -o %ResultDir%Project.dll -Wl,--out-implib,%ResultDir%Project.lib %ObjectFiles% -L%ESLibraryDir% -lgc
) ELSE (
	%CC% -shared -o %ResultDir%Project.dll -Wl,--out-implib,%ResultDir%Project.lib %ObjectFiles% -L%ESLibraryDir% -lgc 2> ignore
)


IF NOT %ErrorLevel% == 0 (
	IF %DebugMode% == 0 (
		ECHO Interal error
	)
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)


:: 외부 라이브러리 Dll 파일 복사
IF NOT %DebugMode% == 0 (
	ECHO.
	ECHO COPY %ESLibraryDir%gc.dll %ResultDir%. 
	COPY %ESLibraryDir%gc.dll %ResultDir%.
) ELSE (
COPY %ESLibraryDir%gc.dll %ResultDir%. > ignore
)

IF NOT %ErrorLevel% == 0 (
	SET ExitCode=%ErrorLevel%
	GOTO :EXIT
)


:EXIT

:: 호출한 위치로 전환
CD /D %PrevDir%

:: 일시 정지 (자동 종료 방해)
ECHO.
PAUSE

EXIT /B %ExitCode%
