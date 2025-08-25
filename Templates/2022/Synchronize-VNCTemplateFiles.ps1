<#
    Synchronize-VNCTemplateFiles.ps1

    Description

    TODO(crhodes)
    Turn into proper script with description and usage
#>

#region Variables and Configuration

# Set to A for ProjectTemplatesA and ItemTemplatesA,
# Set to B for ...

$AB = "A"

$templateFolder = "V:\Dropbox\Visual Studio\2022\Templates"

# templateMaster and templateCoreMaster are the most complete projects
# with the complete set of files.

$templateMaster = "VNC_PT_APPLICATION_PrismDxWPF_EF"

$sourceMaster = "ProjectTemplates$($AB)\VNC\$($templateMaster)"

$templateCoreMaster = "VNC_PT_APPLICATION.Core_EF"

$sourceCoreMaster = "ProjectTemplates$($AB)\VNC\$($templateCoreMaster)"


#$VerbosePreference = 'Continue'
$VerbosePreference = 'Ignore'

# set to $false to have the magic just happen, $true to prompt before changes

$confirmUpdate = $false

# $ErrorActionPreference = 'Break'

$projectTemplates = "ProjectTemplates$AB\VNC"
$itemTemplates = "ItemTemplates$AB\VNC"

# targetProjectTemplateFolders contain projects 
# with a subset of the files in templateMaster

$targetProjectTemplateFolders = @(
    "VNC_PT_APPLICATION_PrismDxWPF"
    , "VNC_PT_APPLICATION_PrismDxWPF_Simple"
    , "VNC_PT_APPLICATION.Domain"
    , "VNC_PT_APPLICATION.DomainServices"
    , "VNC_PT_MODULE"
    , "VNC_PT_MODULE_EF"
)

# targetCoreTemplateFolders contain projects 
# with a subset of the files in templateCoreMaster

$targetCoreTemplateFolders = @(
    "VNC_PT_APPLICATION.Core"
)

$targetItemTemplateFolders = @(
    "VNC_IT_MVVM_All"
    , "VNC_IT_MVVM_V"
    , "VNC_IT_MVVM_V_VM"
    , "VNC_IT_MODULE_MVVM_V_VM" # How is this different. Do we really need
    , "VNC_IT_EmbeddedWPFControl"
)

$manualProcesingRequired = @(
    #Files
    "App.Config"
    , "APPLICATION.csproj"
    , "Common.cs" # VNC_PT_MODULE different
    # Presentation\Views
    , "Presentation\Views\MainDxDockLayoutManager.xaml"
    , "Presentation\Views\MainDxLayoutControl.xaml"
)

$masterFileUpdated = $false

$masterCoreFileUpdated = $false

# Any file that is commented out varies by template.
# It is left here to ensure we have thought about all files

$commonProjectFiles = @(
    # Files
    "_ReadMe.txt"
    # "App.Config.cs"
    , "App.Xaml"
    , "App.Xaml.cs"
    # , "APPLICATION.csproj"
    # , "Common.cs" # MODULE is different
    , "vncloggingconfig.json"
    , "vncloggingconfig-debug.json"
    , "vnccoreloggingconfig.json"
    , "vnccoreloggingconfig-debug.json"
    # Application
    , "Application\_ReadMe.txt"
    # ApplicationServices
    , "ApplicationServices\_ReadMe.txt"
    # Domain
    , "Domain\_ReadMe.txt"
    # Domain\Lookups
    , "Domain\Lookups\_ReadMe.txt"
    # DomainServices
    , "DomainServices\_ReadMe.txt"
    # DomainServices\ServicesMock
   , "DomainServices\ServicesMock\_ReadMe.txt"
    # Infrastructure
    , "Infrastructure\_ReadMe.txt"
    # Modules
    , "Modules\_ReadMe.txt"    
    , "Modules\APPLICATIONModule.cs"
    , "Modules\APPLICATIONServicesModule.cs"
    # Persistence
    , "Persistence\_ReadMe.txt"
    # Persistence\Database
    , "Persistence\Database\_ReadMe.txt"    
    , "Persistence\Database\APPLICATIONDbContext.cs"
    # Persistence\Database\Migrations
    , "Persistence\Database\Migrations\_ReadMe.txt"
    # Presentation
    , "Presentation\_ReadMe.txt"
    # Presentation\Converters
    , "Presentation\Converters\_ReadMe.txt"
    # Presentation\ModelWrappers
    , "Presentation\ModelWrappers\_ReadMe.txt"
    # Presentation\ViewModels
    , "Presentation\ViewModels\_ReadMe.txt"    
    , "Presentation\ViewModels\AboutViewModel.cs"
    , "Presentation\ViewModels\CombinedMainViewModel.cs"
    , "Presentation\ViewModels\CombinedNavigationViewModel.cs"
    , "Presentation\ViewModels\MainDxDockLayoutManagerViewModel.cs"
    , "Presentation\ViewModels\MainDxLayoutControlViewModel.cs"
    , "Presentation\ViewModels\MainViewModel.cs"
    , "Presentation\ViewModels\MultiStepProcessViewModel.cs"
    , "Presentation\ViewModels\RegionNavigationViewModel.cs"
    , "Presentation\ViewModels\RibbonSimpleViewModel.cs"    
    , "Presentation\ViewModels\RibbonViewModel.cs"
    , "Presentation\ViewModels\StatusBarViewModel.cs"
    , "Presentation\ViewModels\StepABCDEViewModel.cs"
    , "Presentation\ViewModels\UILaunchApproachesViewModel.cs"
    , "Presentation\ViewModels\ViewABCDViewModel.cs"
    , "Presentation\ViewModels\ViewAViewModel.cs"
    , "Presentation\ViewModels\ViewBViewModel.cs"
    , "Presentation\ViewModels\ViewCViewModel.cs"
    , "Presentation\ViewModels\ViewDiscoveryViewModel.cs"    
    , "Presentation\ViewModels\ViewDViewModel.cs"
    , "Presentation\ViewModels\ViewInjectionViewModel.cs"
    # Presentation\ViewModels\Shells
    , "Presentation\ViewModels\Shells\_ReadMe.txt"    
    # , "Presentation\ViewModels\Shells\RibbonShellViewModel.cs"
    , "Presentation\ViewModels\Shells\ShellViewModel.cs"
    # Presentation\Views
    , "Presentation\Views\_ReadMe.txt"    
    , "Presentation\Views\About.xaml"
    , "Presentation\Views\About.xaml.cs"
    , "Presentation\Views\AppVersionInfo.xaml"
    , "Presentation\Views\AppVersionInfo.xaml.cs"
    , "Presentation\Views\CombinedMain.xaml"
    , "Presentation\Views\CombinedMain.xaml.cs"
    , "Presentation\Views\CombinedNavigation.xaml"
    , "Presentation\Views\CombinedNavigation.xaml.cs"
    , "Presentation\Views\Main.xaml"
    , "Presentation\Views\Main.xaml.cs"
    # , "Presentation\Views\MainDxDockLayoutManager.xaml"
    , "Presentation\Views\MainDxDockLayoutManager.xaml.cs"
    # , "Presentation\Views\MainDxLayoutControl.xaml"
    , "Presentation\Views\MainDxLayoutControl.xaml.cs"
    , "Presentation\Views\MultiStepProcess.xaml"
    , "Presentation\Views\MultiStepProcess.xaml.cs"
    , "Presentation\Views\RegionNavigation.xaml"
    , "Presentation\Views\RegionNavigation.xaml.cs"
    , "Presentation\Views\Ribbon.xaml"
    , "Presentation\Views\Ribbon.xaml.cs"
    , "Presentation\Views\RibbonSimple.xaml"
    , "Presentation\Views\RibbonSimple.xaml.cs"
    , "Presentation\Views\StatusBar.xaml"
    , "Presentation\Views\StatusBar.xaml.cs"
    , "Presentation\Views\StepA.xaml"
    , "Presentation\Views\StepA.xaml.cs"
    , "Presentation\Views\StepB.xaml"
    , "Presentation\Views\StepB.xaml.cs"
    , "Presentation\Views\StepC.xaml"
    , "Presentation\Views\StepC.xaml.cs"
    , "Presentation\Views\StepD.xaml"
    , "Presentation\Views\StepD.xaml.cs"
    , "Presentation\Views\StepE.xaml"
    , "Presentation\Views\StepE.xaml.cs"
    , "Presentation\Views\UILaunchApproaches.xaml"
    , "Presentation\Views\UILaunchApproaches.xaml.cs"
    , "Presentation\Views\ViewA.xaml"
    , "Presentation\Views\ViewA.xaml.cs"
    , "Presentation\Views\ViewB.xaml"
    , "Presentation\Views\ViewB.xaml.cs"
    , "Presentation\Views\ViewC.xaml"
    , "Presentation\Views\ViewC.xaml.cs"
    , "Presentation\Views\ViewD.xaml"
    , "Presentation\Views\ViewD.xaml.cs"
    , "Presentation\Views\ViewABCD.xaml"
    , "Presentation\Views\ViewABCD.xaml.cs"
    , "Presentation\Views\ViewDiscovery.xaml"
    , "Presentation\Views\ViewDiscovery.xaml.cs"
    , "Presentation\Views\ViewInjection.xaml"
    , "Presentation\Views\ViewInjection.xaml.cs"
    # Presentation\Views\Shells
    , "Presentation\Views\Shells\_ReadMe.txt"    
    # , "Presentation\Views\Shells\RibbonShell.xaml"
    , "Presentation\Views\Shells\Shell.xaml"
    , "Presentation\Views\Shells\Shell.xaml.cs"
    # Presentation\UserControls
    , "Presentation\Views\UserControls\_ReadMe.txt"
    # Resources
    , "Resources\_ReadMe.txt"
    # Resources\Icons
    , "Resources\Icons\_ReadMe.txt"    
    , "Resources\Icons\ApplicationIcon.ico"
    , "Resources\Icons\ApplicationIcon-Left-Blue.ico"
    , "Resources\Icons\ApplicationIcon-Left-Blue.png"
    , "Resources\Icons\ApplicationIcon-Left-Blue.psd"
    , "Resources\Icons\ApplicationIcon-Right-Red.ico"
    , "Resources\Icons\ApplicationIcon-Right-Red.png"
    , "Resources\Icons\ApplicationIcon-Right-Red.psd"
    # Resources\Images
   , "Resources\Images\_ReadMe.txt"    
    , "Resources\Images\FilterEditor.png"
    , "Resources\Images\ToolBox.png"
    , "Resources\Images\VNCDeveloperMotivation.png"
    , "Resources\Images\WatchWindow.bmp" 
    # Resources\Xmal
    , "Resources\Xaml\_ReadMe.txt"    
    , "Resources\Xaml\Application.xaml"
    , "Resources\Xaml\Display_StylesAndTemplates.xaml"
    , "Resources\Xaml\Layout_Styles.xaml"
)

# NOTE(crhodes)
# No need for _ReadMe.txt files here
# commonProjectFiles should have already placed
# appropriate _ReadMe.txt files in folders

$commonItemFiles = @(
    # Domain
      "Domain\ITEM.cs"
    , "Domain\TYPE.cs"
    , "Domain\TYPEEmailAddress.cs"
    , "Domain\TYPEPhoneNumber.cs"
    # Domain\Lookups
    , "Domain\Lookups\LookupTYPE.cs"
    # DomainServices
    , "DomainServices\ITEMDataService.cs"
    , "DomainServices\ITEMLookupDataService.cs"
    , "DomainServices\TYPEDataService.cs"
    , "DomainServices\TYPELookupDataService.cs"
    # DomainServices\ServicesMock
    , "DomainServices\ServicesMock\TYPEDataServiceMock.cs"
    # Modules
    , "Modules\TYPEModule.cs"
    # Presentation\Converters
    # Presentation\ModelWrappers
    , "Presentation\ModelWrappers\ITEMWrapper.cs"
    , "Presentation\ModelWrappers\TYPEPhoneNumberWrapper.cs"
    , "Presentation\ModelWrappers\TYPEWrapper.cs"
    # Presentation\ViewModels
    , "Presentation\ViewModels\ITEMDetailViewModel.cs"
    , "Presentation\ViewModels\TYPEDetailMVViewModel.cs"    
    , "Presentation\ViewModels\TYPEDetailViewModel.cs"  
    , "Presentation\ViewModels\TYPEMainMVViewModel.cs"      
    , "Presentation\ViewModels\TYPEMainViewModel.cs"
    , "Presentation\ViewModels\TYPENavigationMVViewModel.cs"    
    , "Presentation\ViewModels\TYPENavigationViewModel.cs"
    , "Presentation\ViewModels\TYPEViewModel.cs"
    # Presentation\Views
    , "Presentation\Views\ITEMDetail.xaml"
    , "Presentation\Views\ITEMDetail.xaml.cs"
    , "Presentation\Views\TYPE.xaml"
    , "Presentation\Views\TYPE.xaml.cs"
    , "Presentation\Views\TYPEMain.xaml"
    , "Presentation\Views\TYPEMain.xaml.cs"
    , "Presentation\Views\TYPENavigation.xaml"
    , "Presentation\Views\TYPENavigation.xaml.cs"
    , "Presentation\Views\TYPEDetail.xaml"
    , "Presentation\Views\TYPEDetail.xaml.cs"
    , "Presentation\Views\TYPEMainMV.xaml"
    , "Presentation\Views\TYPEMainMV.xaml.cs"
    , "Presentation\Views\TYPENavigationMV.xaml"
    , "Presentation\Views\TYPENavigationMV.xaml.cs"
    , "Presentation\Views\TYPEDetailMV.xaml"
    , "Presentation\Views\TYPEDetailMV.xaml.cs"
    # Presentation\Views\UserControls
    # , "Presentation\Views\UserControls\TYPE.xaml"
    # , "Presentation\Views\UserControls\TYPE.xaml.cs"
)

$commonCoreFiles = @(
    # Files
    "_ReadMe.txt"    
    , "ApplicationCommands.cs"
    , "GlobalCommands.cs"
    , "RegionNames.cs"
    # Application
    , "Application\_ReadMe.txt"    
    , "Application\IDatabaseService.cs"
    , "Application\ILookupService.cs"
    # Application\TYPEs
    , "Application\TYPEs\_ReadMe.txt"
    # Application\TYPEs\Commands
    , "Application\TYPEs\Commands\_ReadMe.txt"
    # Application\TYPEs\Queries
    , "Application\TYPEs\Queries\_ReadMe.txt"    
    , "Application\TYPEs\Queries\IGetTYPEsListQuery.cs"
    # ApplicationServices
    , "ApplicationServices\_ReadMe.txt"
    # DomainServices
    , "DomainServices\_ReadMe.txt"    
    , "DomainServices\IITEMDataService.cs"
    , "DomainServices\IITEMLookupDataService.cs"
    , "DomainServices\ITYPEDataService.cs"
    , "DomainServices\ITYPELookupDataService.cs"
    # Events
    , "Events\_ReadMe.txt"    
    , "Events\AfterTYPESavedEvent.cs"
    , "Events\AfterTYPESavedEventArgs.cs"
    , "Events\OpenTYPEDetailViewEvent.cs"
    # Persistence
    , "Persistence\_ReadMe.txt"
    # Persistence\Database
    , "Persistence\Database\_ReadMe.txt"    
    , "Persistence\Database\IAPPLICATIONDbContext.cs"
    # Presentation
    , "Presentation\_ReadMe.txt"
    # Presentation\ViewModels
    , "Presentation\ViewModels\_ReadMe.txt"    
    , "Presentation\ViewModels\IAboutViewModel.cs"
    , "Presentation\ViewModels\IAppVersionInfoViewModel.cs"
    , "Presentation\ViewModels\ICombinedMainViewModel.cs"
    , "Presentation\ViewModels\ICombinedNavigationViewModel.cs"
    , "Presentation\ViewModels\IITEMDetailViewModel.cs"
    , "Presentation\ViewModels\IMainViewModel.cs"
    , "Presentation\ViewModels\IMultiStepProcessViewModel.cs"
    , "Presentation\ViewModels\IRegionNavigationViewModel.cs"
    , "Presentation\ViewModels\IRibbonViewModel.cs"
    , "Presentation\ViewModels\IStatusBarViewModel.cs"
    , "Presentation\ViewModels\IStepABCDEViewModel.cs"
    , "Presentation\ViewModels\ITYPEDetailViewModel.cs"
    , "Presentation\ViewModels\ITYPEMainViewModel.cs"
    , "Presentation\ViewModels\ITYPENavigationViewModel.cs"
    , "Presentation\ViewModels\ITYPEDetailMVViewModel.cs"
    , "Presentation\ViewModels\ITYPEMainMVViewModel.cs"
    , "Presentation\ViewModels\ITYPENavigationMVViewModel.cs"
    , "Presentation\ViewModels\ITYPEViewModel.cs"
    , "Presentation\ViewModels\IUILaunchApproachesViewModel.cs"
    , "Presentation\ViewModels\IViewABCDViewModel.cs"
    , "Presentation\ViewModels\IViewDiscoveryViewModel.cs"
    , "Presentation\ViewModels\IViewInjectionViewModel.cs"
    # Presentation\ViewModels\Shells
    , "Presentation\ViewModels\Shells\_ReadMe.txt"
    # Presentation\Views
    , "Presentation\Views\_ReadMe.txt"    
    , "Presentation\Views\IAbout.cs"
    , "Presentation\Views\ICombinedMain.cs"
    , "Presentation\Views\ICombinedNavigation.cs"
    , "Presentation\Views\IITEMDetail.cs"
    , "Presentation\Views\IMain.cs"
    , "Presentation\Views\IMultiStepProcess.cs"
    , "Presentation\Views\IRegionNavigation.cs"
    , "Presentation\Views\IRibbon.cs"
    , "Presentation\Views\IStatusBar.cs"
    , "Presentation\Views\IStepA.cs"
    , "Presentation\Views\IStepB.cs"
    , "Presentation\Views\IStepC.cs"
    , "Presentation\Views\IStepD.cs"
    , "Presentation\Views\IStepE.cs"
    , "Presentation\Views\IITEMDetail.cs"
    , "Presentation\Views\ITYPE.cs"
    , "Presentation\Views\ITYPEDetail.cs"
    , "Presentation\Views\ITYPEMain.cs"
    , "Presentation\Views\ITYPENavigation.cs"
    , "Presentation\Views\IUILaunchApproaches.cs"
    , "Presentation\Views\IViewABCD.cs"
    , "Presentation\Views\IViewDiscovery.cs"
    , "Presentation\Views\IViewInjection.cs"
    # Presentation\Views\Shells
    , "Presentation\Views\Shells\_ReadMe.txt"
)

#endregion

#region Functions

function WriteDelimitedMessage($msg)
{
    $delimitS = "********** >>> "
    $delimitE = " <<< **********"
    # $delimitS = ""
    # $delimitE = ""

    Write-Host ""
    # Write-Host -ForegroundColor Red $delimitS ("{0,-30}" -f $msg) $delimitE
    Write-Host -ForegroundColor Red $delimitS ("{0}" -f $msg) $delimitE
    Write-Host ""
}

function CompareAndUpdateFile ([System.IO.FileInfo]$masterFile, [System.IO.FileInfo]$targetFile, [string] $targetTemplateFolder)
{
    if ($masterFile.LastWriteTime -ne $targetFile.LastWriteTime)
    {
        Write-Verbose "  master: $($masterFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))"
        Write-Verbose "  target: $($targetFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))"
        if ($masterFile.LastWriteTime -gt $targetFile.LastWriteTime)
        {
            $newer = "Master"
            [System.ConsoleColor]$foreGroundColor = "Green"
        }
        else
        {
            $newer = "Target"
            [System.ConsoleColor]$foreGroundColor = "DarkYellow"
        }

        # Write-Host -ForegroundColor Red "$($masterFile.Name) $($masterFile.LastWriteTime) $($masterFile.Length)"
        Write-Host -ForegroundColor Yellow " > $($targetFile.Name) $($targetFile.LastWriteTime) $($targetFile.Length)"
        Write-Host "   in $($targetTemplateFolder)"
        Write-Host -ForegroundColor $foreGroundColor.ToString() "    Last Write Time Different - $newer newer"

        if ($masterFile.LastWriteTime -gt $targetFile.LastWriteTime)
        {
            Write-Host -ForegroundColor Green "      master: " $masterFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff")
            Write-Host "      target: " $targetFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff")

            if ($confirmUpdate)
            {
                while( -not ( ($choice= (Read-Host "Copy Master to Target")) -match "^(y|n)$")){ "Y or N ?"}

                if ($choice -eq "y")
                {
                    Write-Host "Copying Master to Target"
                    Copy-Item -Path $masterFile -Destination $targetFile
                    $targetFile.LastWriteTime = $masterFile.LastWriteTime

                    Write-Verbose "  master: $($masterFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))"
                    Write-Verbose "  target: $($targetFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))"

                    # Read-Host "Enter to continue"
                }
                else
                {
                    "Skipping"
                }
            }
            else
            {
                Write-Host "Copying Master to Target"
                Copy-Item -Path $masterFile -Destination $targetFile
            }
        }
        else
        {
            Write-Host -ForegroundColor DarkYellow "      target: " $targetFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff")
            Write-Host "      master: " $masterFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff")

            if ($confirmUpdate)
            {
                while( -not ( ($choice= (Read-Host "Copy Target to Master")) -match "^(y|n)$")){ "Y or N ?"}

                if ($choice -eq "y")
                {
                    Write-Host "Copying Target to Master"
                    Copy-Item -Path $targetFile -Destination $masterFile
                    $masterFile.LastWriteTime = $targetFile.LastWriteTime

                    Write-Verbose "  master: $($masterFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))"
                    Write-Verbose "  target: $($targetFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))"

                    # Read-Host "Enter to continue"
                }
                else
                {
                    "Skipping"
                }
            }
            else
            {
                Write-Host "Copying Target to Master"
                Copy-Item -Path $targetFile -Destination $masterFile
            }

            # This means masterFile may need to propagate to other places

            $script:masterFileUpdated = $true
        }
    }
    else
    {
        Write-Verbose "LastWriteTime match"

        if ($masterFile.Length -ne $targetFile.Length)
        {
            Write-Host "++++++++++ Lengths do not match ++++++++++ Using Master"

            Copy-Item -Path $masterFile -Destination $targetFile
            $targetFile.LastWriteTime = $masterFile.LastWriteTime
        }
        else
        {
            Write-Verbose "Length Match"
        }
    }
}

function UpdateMatchingFiles([string] $masterFile)
{
    if (Test-Path $sourceMaster\$masterFile)
    {
        $masterFileInfo = Get-ChildItem $sourceMaster\$masterFile

        Write-Host -ForegroundColor Blue ("{0,-60} - {1} {2}" -f $masterFile, $masterFileInfo.LastWriteTime, $masterFileInfo.Length)
        # Write-Host -ForegroundColor Red "$($templateMaster)\$($masterFile) $($masterFileInfo.LastWriteTime) $($masterFileInfo.Length)"

        foreach ($targetTemplateFolder in $targetProjectTemplateFolders)
        {
            Write-Verbose "Checking files in $($projectTemplates)\$($targetTemplateFolder)"

            # NOTE(crhodes)
            # This needs to be smarter as files can exist at top level or in a sub folder
            # Usually there is only one matching file in a template
            #
            # Special case for _ReadMe.txt

            if ($masterFile -match "_ReadMe.txt")
            {
                if (TEST-PATH "$($projectTemplates)\$($targetTemplateFolder)\$($masterFile)")
                {
                    $fileInfo = Get-ChildItem "$($projectTemplates)\$($targetTemplateFolder)\$($masterFile)"
                    Write-Verbose " > $($fileInfo.Name) $($fileInfo.LastWriteTime) $($fileInfo.Length)  in  $projectTemplates\$targetTemplateFolder"

                    CompareAndUpdateFile $masterFileInfo $fileInfo "$($projectTemplates)\$($targetTemplateFolder)"
                }
            }
            else
            {
                # TODO(crhodes)
                # Need to get just FileName from $masterFile as can be
                # foo.cs
                # Folder\foo.cs
                # etc

                $masterFileName = $masterFile -split "\\"

                if ($masterFileName.Count -ne 1)
                {
                    Write-Verbose $masterFileName[-1]
                }

                $targetFile = get-childItem -Path "$($projectTemplates)\$($targetTemplateFolder)" -File $($masterFileName[-1]) -Recurse

                if ($targetFile.Count -eq 1)
                {
                    if ($null -ne $targetFile)
                    {
                        Write-Verbose $targetFile
                        Write-Verbose " >  $($targetFile.Name) $($targetFile.LastWriteTime) $($targetFile.Length)  in  $projectTemplates\$targetTemplateFolder"

                        CompareAndUpdateFile $masterFileInfo $targetFile "$($projectTemplates)\$($targetTemplateFolder)"
                    }
                }
                elseif ($targetFile.Count -gt 1)
                {
                    Write-Error "WTF $masterFile exists $targetFile.Count times!!!"#>
                }
                else
                {
                    Write-Verbose "No matching file"
                }
            }
        }

        Write-Verbose ""
    }
    else
    {
        Write-Error "$sourceMaster\$masterFile does not exist"
    }
}

function UpdateMatchingCoreFiles([string] $masterCoreFile)
{
    if (Test-Path $sourceCoreMaster\$masterCoreFile)
    {
        $masterCoreFileInfo = Get-ChildItem $sourceCoreMaster\$masterCoreFile

        Write-Host -ForegroundColor Blue ("{0,-60} - {1} {2}" -f $masterCoreFile, $masterCoreFileInfo.LastWriteTime, $masterCoreFileInfo.Length)
        # Write-Host -ForegroundColor Red "$($templateMaster)\$($masterCoreFile) $($masterCoreFileInfo.LastWriteTime) $($masterCoreFileInfo.Length)"

        foreach ($targetTemplateFolder in $targetProjectTemplateFolders)
        {
            Write-Verbose "Checking files in $($projectTemplates)\$($targetTemplateFolder)"

            # NOTE(crhodes)
            # This needs to be smarter as files can exist at top level or in a sub folder
            # Usually there is only one matching file in a template
            #
            # Special case for _ReadMe.txt

            if ($masterCoreFile -match "_ReadMe.txt")
            {
                if (TEST-PATH "$($projectTemplates)\$($targetTemplateFolder)\$($masterCoreFile)")
                {
                    $fileInfo = Get-ChildItem "$($projectTemplates)\$($targetTemplateFolder)\$($masterCoreFile)"
                    Write-Verbose " > $($fileInfo.Name) $($fileInfo.LastWriteTime) $($fileInfo.Length)  in  $projectTemplates\$targetTemplateFolder"

                    CompareAndUpdateFile $masterCoreFileInfo $fileInfo "$($projectTemplates)\$($targetTemplateFolder)"
                }
            }
            else
            {
                # TODO(crhodes)
                # Need to get just FileName from $masterCoreFile as can be
                # foo.cs
                # Folder\foo.cs
                # etc

                $masterCoreFileName = $masterCoreFile -split "\\"

                if ($masterCoreFileName.Count -ne 1)
                {
                    Write-Verbose $masterCoreFileName[-1]
                }

                $targetFile = get-childItem -Path "$($projectTemplates)\$($targetTemplateFolder)" -File $($masterCoreFileName[-1]) -Recurse

                if ($targetFile.Count -eq 1)
                {
                    if ($null -ne $targetFile)
                    {
                        Write-Verbose $targetFile
                        Write-Verbose " >  $($targetFile.Name) $($targetFile.LastWriteTime) $($targetFile.Length)  in  $projectTemplates\$targetTemplateFolder"

                        CompareAndUpdateFile $masterCoreFileInfo $targetFile "$($projectTemplates)\$($targetTemplateFolder)"
                    }
                }
                elseif ($targetFile.Count -gt 1)
                {
                    Write-Error "WTF $masterCoreFile exists $targetFile.Count times!!!"#>
                }
                else
                {
                    Write-Verbose "No matching file"
                }
            }
        }

        Write-Verbose ""
    }
    else
    {
        Write-Error "$sourceCoreMaster\$masterCoreFile does not exist"
    }
}

function ProcessProjectFiles()
{
    Write-Host ""
    Write-Host "---------- Processsing all commonProjectFiles for ProjectTemplates ----------"
    Write-Host ""

    foreach ($masterFile in $commonProjectFiles)
    {
        UpdateMatchingFiles $masterFile
    }

    Write-Host ""
    Write-Host "---------- Processing all commonItemFiles for ProjectTemplates ----------"
    Write-Host ""

    foreach ($masterFile in $commonItemFiles)
    {
        UpdateMatchingFiles $masterFile
    }
}

function ProcessItemFiles()
{
    Write-Host ""
    Write-Host "---------- Processing all commonItemFiles for ItemTemplates ----------"
    Write-Host ""

    foreach ($masterFile in $commonItemFiles)
    {
        if (Test-Path $sourceMaster\$masterFile)
        {
            $masterFileInfo = Get-ChildItem $sourceMaster\$masterFile

            Write-Host -ForegroundColor Blue ("{0,-60} - {1} {2}" -f $masterFile, $masterFileInfo.LastWriteTime, $masterFileInfo.Length)

            # Write-Verbose "$($masterFile) $($masterFileInfo.LastWriteTime) $($masterFileInfo.Length)"

            foreach ($templateFolder in $targetItemTemplateFolders)
            {
                Write-Verbose "Checking files in $itemTemplates\$templateFolder"
                # Write-Host "Checking files in $itemTemplates\$templateFolder"

                # Need to strip all but the last part of the name
                # as files go in the top level folder

                $masterFilePath = $masterFile.Split('\')
                $targetFile = $masterFilePath[$masterFilePath.Count-1]

                if (TEST-PATH $itemTemplates\$templateFolder\$targetFile)
                {
                    $fileInfo = Get-ChildItem $itemTemplates\$templateFolder\$targetFile
                    Write-Verbose " >  $($fileInfo.Nam) $($fileInfo.LastWriteTime) $($fileInfo.Length)  in  $itemTemplates\$templateFolder"

                    CompareAndUpdateFile $masterFileInfo $fileInfo "$($itemTemplates)\$($templateFolder)"
                }
            }

            Write-Verbose ""
        }
    }
}

function ProcessCoreFiles()
{
    Write-Host ""
    Write-Host "---------- Processsing all commonCoreFiles for Core ProjectTemplates ----------"
    Write-Host ""

    foreach ($masterCoreFile in $commonCoreFiles)
    {
        UpdateMatchingCoreFiles $masterCoreFile
    }
}

#endregion

Set-Location $templateFolder

WriteDelimitedMessage "Updating VNC Visual Studio Templates using files in"
Write-Host -ForegroundColor Red "  >>> $(Get-Location)\$($sourceMaster)"

ProcessProjectFiles

ProcessItemFiles

if ($masterFileUpdated)
{
    Write-Host "Master file(s) updated.  Propagating changes"
    ProcessProjectFiles
    ProcessItemFiles
}

ProcessCoreFiles

if ($masterCoreFileUpdated)
{
    Write-Host "Master Core file(s) updated.  Propagating changes"
    ProcessCoreFiles
}

WriteDelimitedMessage "Synchronization Complete !"


# Read-Host -Prompt "Press Enter to Exit"

# End of .\Synchronize-VNCTemplateFiles.ps1