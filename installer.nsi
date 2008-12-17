; example2.nsi
;
; This script is based on example1.nsi, but it remember the directory, 
; has uninstall support and (optionally) installs start menu shortcuts.
;
; It will install example2.nsi into a directory that the user selects,

;--------------------------------

; The name of the installer
Name "Transmission Remote"

; The file to write
OutFile "transmission-remote-3.0rc1-installer.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\Transmission Remote"

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKCU "Software\TransmissionRemote" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Transmission Remote (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "Transmission Remote.exe"
  File "Jayrock.dll"
  File "Jayrock.Json.dll"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\NSIS_Example2 "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Transmission Remote" "DisplayName" "Transmission Remote"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Transmission Remote" "Publisher" "Alan F"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Transmission Remote" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Transmission Remote" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Transmission Remote" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\Transmission Remote"
  CreateShortCut "$SMPROGRAMS\Transmission Remote\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\Transmission Remote\Transmission Remote.lnk" "$INSTDIR\Transmission Remote.exe" "" "$INSTDIR\Transmission Remote.exe" 0
  
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Example2"
  DeleteRegKey HKLM SOFTWARE\TransmissionRemote

  ; Remove files and uninstaller
  Delete "$INSTDIR\Transmission Remote.exe"
  Delete "$INSTDIR\Jayrock.dll"
  Delete "$INSTDIR\Jayrock.Json.dll"
  Delete "$INSTDIR\uninstall.exe"

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\Transmission Remote\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\Transmission Remote"
  RMDir "$INSTDIR"

SectionEnd
