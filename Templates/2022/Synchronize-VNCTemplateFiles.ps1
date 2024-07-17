
function WriteDelimitedMessage($msg)
{
    # $delimitS = "**********> "
    # $delimitE = " <**********"
    $delimitS = ""
    $delimitE = ""

    Write-Host -ForegroundColor Red $delimitS ("{0,-30}" -f $msg) $delimitE
}

$AB = "A"   # Set to A for ProjectTemplatesA and ItemTemplatesA, Set to B for ...

#$VerbosePreference = 'Continue'
$VerbosePreference = 'Ignore'
$confirmUpdate = $true
# $ErrorActionPreference = 'Break'

$templateFolder = "V:\Dropbox\Visual Studio\2022\Templates"

$sourceMaster = "ProjectTemplates$AB\VNC\VNC_PT_APPLICATION_PrismDxWPF_EF"
$templateMaster = "VNC_PT_APPLICATION_PrismDxWPF_EF"

$projectTemplates = "ProjectTemplates$AB\VNC"
$itemTemplates = "ItemTemplates$AB\VNC"

$targetProjectTemplateFolders = @(
    "VNC_PT_APPLICATION_PrismDxWPF"
    , "VNC_PT_APPLICATION.Domain"  
    , "VNC_PT_APPLICATION.DomainServices"  
    , "VNC_PT_MODULE"   
    # Big problem with all MODULE files $xxxMODULExxx$ vs $xxxAPPLICATIONxxx$
    # Think through how to handle.  Maybe duplicate lines
    # or does it really matter.  Do we need a MODULE parameter?
)

$targetItemTemplateFolders = @(
    "VNC_IT_MVVM_All"
    , "VNC_IT_MVVM_V"
    , "VNC_IT_MVVM_V_VM"
    , "VNC_IT_MODULE_MVVM_V_VM" # How is this different. Do we really need
)

$manualProcesingRequired = @(
    #Files
    "App.Config"     
    , "APPLICATION.csproj"
    , "Common.cs" # VNC_PT_MODULE different
    # Presentation\Views
    , "Presentation\Views\MainDxDocLayoutManager.xaml"
    , "Presentation\Views\MainDxDocLayoutManager.xaml.cs"   # this might be the same
    , "Presentation\Views\MainDxLayout.xaml"
    , "Presentation\Views\MainDxLayout.xaml.cs"             # this might be the same
)

$masterFileUpdated = $false

$commonProjectFiles = @(
    # Files
    # "App.Config.cs" 
    , "App.Xaml" 
    , "App.Xaml.cs"
    # , "APPLICATION.csproj"
    # , "Common.cs"
    , "vncloggingconfig.json"
    , "vncloggingconfig-debug.json"
    , "vnccoreloggingconfig.json"
    , "vnccoreloggingconfig-debug.json"        
    , "ReadMe.txt" 
    # Application
    , "Application\ReadMe.txt"
    # ApplicationServices
    , "ApplicationServices\ReadMe.txt"                 
    # DomainServices
    , "DomainServices\ReadMe.txt"    
    # Infrastructure
    , "Infrastructure\ReadMe.txt"    
    # Modules
    , "Modules\APPLICATIONModule.cs" 
    , "Modules\APPLICATIONServicesModule.cs" 
    , "Modules\ReadMe.txt"        
    # Persistence\Database\Migrations
    , "Persistence\Database\Migrations\ReadMe.txt"
    # Persistence\Database

    , "Persistence\Database\APPLICATIONDbContext.cs"   
    , "Persistence\Database\ReadMe.txt"          
    # Persistence
    , "Persistence\ReadMe.txt"  
    # Presentation\Converters
    , "Presentation\Converters\ReadMe.txt"      
    # Presentation\ModelWrappers
    , "Presentation\ModelWrappers\ReadMe.txt"  
    # Presentation\Views\Shells
    , "Presentation\Views\Shells\RibbonShell.xaml"
    , "Presentation\Views\Shells\RibbonShell.xaml.cs"
    , "Presentation\Views\Shells\Shell.xaml"
    , "Presentation\Views\Shells\Shell.xaml.cs"
    , "Presentation\Views\Shells\ReadMe.txt"    
    # Presentation\Views
    , "Presentation\Views\AppVersionInfo.xaml"
    , "Presentation\Views\AppVersionInfo.xaml.cs"
    , "Presentation\Views\CombinedMain.xaml"
    , "Presentation\Views\CombinedMain.xaml.cs"  
    , "Presentation\Views\CombinedNavigation.xaml"
    , "Presentation\Views\CombinedNavigation.xaml.cs"
    , "Presentation\Views\Main.xaml"
    , "Presentation\Views\Main.xaml.cs"    
    # , "Presentation\Views\MainDxDocLayoutManager.xaml"
    # , "Presentation\Views\MainDxDocLayoutManager.xaml.cs"
    # , "Presentation\Views\MainDxLayout.xaml"
    # , "Presentation\Views\MainDxLayout.xaml.cs"            
    , "Presentation\Views\Ribbon.xaml"
    , "Presentation\Views\Ribbon.xaml.cs"   
    , "Presentation\Views\StatusBar.xaml"
    , "Presentation\Views\StatusBar.xaml.cs"        
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
    , "Presentation\Views\UILaunchApproaches.xaml"
    , "Presentation\Views\UILaunchApproaches.xaml.cs"
    , "Presentation\Views\ReadMe.txt"    
    # Presentation\ViewModels\Shells
    , "Presentation\ViewModels\Shells\RibbonShellViewModel.cs"
    , "Presentation\ViewModels\Shells\ShellViewModel.cs"
    , "Presentation\ViewModels\Shells\ReadMe.txt"   
    # Presentation\ViewModels
    , "Presentation\ViewModels\CombinedMainViewModel.cs"
    , "Presentation\ViewModels\CombinedNavigationViewModel.cs"        
    , "Presentation\ViewModels\MainDxDockLayoutManagerViewModel.cs"
    , "Presentation\ViewModels\MainDxLayoutControlViewModel.cs"
    , "Presentation\ViewModels\MainViewModel.cs"
    , "Presentation\ViewModels\RibbonViewModel.cs"
    , "Presentation\ViewModels\StatusBarViewModel.cs"        
    , "Presentation\ViewModels\UILaunchApproachesViewModel.cs"            
    , "Presentation\ViewModels\ViewABCDViewModel.cs" 
    , "Presentation\ViewModels\ViewAViewModel.cs"
    , "Presentation\ViewModels\ViewBViewModel.cs" 
    , "Presentation\ViewModels\ViewCViewModel.cs" 
    , "Presentation\ViewModels\ViewDViewModel.cs"
    , "Presentation\ViewModels\ReadMe.txt"    
    # Resources\Icons
    , "Resources\Icons\applicationIcon.ico"
    , "Resources\Icons\ApplicationIcon-Left-Blue.ico"
    , "Resources\Icons\ApplicationIcon-Left-Blue.png"
    , "Resources\Icons\ApplicationIcon-Left-Blue.psd"
    , "Resources\Icons\ApplicationIcon-Right-Red.ico"
    , "Resources\Icons\ApplicationIcon-Right-Red.png"
    , "Resources\Icons\ApplicationIcon-Right-Red.psd"
    , "Resources\Icons\ReadMe.txt"     
    # Resources\Images
    , "Resources\Images\VNCDeveloperMotivation.png"
    , "Resources\Images\ReadMe.txt"     
    # Resources\Xmal
    , "Resources\Xaml\Application.xaml"
    , "Resources\Xaml\Display_StylesAndTemplates.xaml"   
    , "Resources\Xaml\Layout_Styles.xaml"  
    , "Resources\Xaml\ReadMe.txt"                       
    # Resources
    , "Resources\ReadMe.txt"              
)

# NOTE(crhodes)
# No need for ReadMe.txt files here
# commonProjectFiles should have already placed
# appropriate ReadMe.txt files in folders

$commonItemFiles = @(
    # Domain\Lookups
    , "Domain\Lookups\LookupTYPE.cs"
    # Domain 
    , "Domain\ITEM.cs"
    , "Domain\TYPE.cs"    
    , "Domain\TYPEEmailAddress.cs"    
    , "Domain\TYPEPhoneNumber.cs" 
    # DomainServices\ServicesMock
    , "DomainServices\ServicesMock\TYPEDataServiceMock.cs"     
    # DomainServices
    , "DomainServices\ITEMDataService.cs"   
    , "DomainServices\ITEMLookupDataService.cs"   
    , "DomainServices\TYPEDataService.cs"     
    , "DomainServices\TYPELookupDataService.cs"
    # Modules
    , "Modules\TYPEModule.cs"
    # Presentation\Converters 

    # Presentation\ModelWrappers
    , "Presentation\ModelWrappers\ITEMWrapper.cs"
    , "Presentation\ModelWrappers\TYPEPhoneNumberWrapper.cs"  
    , "Presentation\ModelWrappers\TYPEWrapper.cs"                  
    # Presentation\Views
    , "Presentation\Views\TYPE.xaml"
    , "Presentation\Views\TYPE.xaml.cs"
    , "Presentation\Views\TYPEMain.xaml"
    , "Presentation\Views\TYPEMain.xaml.cs"
    , "Presentation\Views\TYPENavigation.xaml"
    , "Presentation\Views\TYPENavigation.xaml.cs"     
    , "Presentation\Views\TYPEDetail.xaml"
    , "Presentation\Views\TYPEDetail.xaml.cs"
    , "Presentation\Views\ITEMDetail.xaml"
    , "Presentation\Views\ITEMDetail.xaml.cs"  
    # Presentation\ViewModels     
    , "Presentation\ViewModels\TYPEViewModel.cs"
    , "Presentation\ViewModels\TYPEMainViewModel.cs"
    , "Presentation\ViewModels\TYPENavigationViewModel.cs"
    , "Presentation\ViewModels\TYPEDetailViewModel.cs" 
    , "Presentation\ViewModels\ITEMDetailViewModel.cs"     
)

Set-Location $templateFolder

Write-Host (Get-Location) $sourceMaster

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
        Write-Host " > $($targetFile.Name) $($targetFile.LastWriteTime) $($targetFile.Length)"
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

        Write-Host -ForegroundColor Red ("{0,-60} - {1} {2}" -f $masterFile, $masterFileInfo.LastWriteTime, $masterFileInfo.Length)
        # Write-Host -ForegroundColor Red "$($templateMaster)\$($masterFile) $($masterFileInfo.LastWriteTime) $($masterFileInfo.Length)"

        foreach ($targetTemplateFolder in $targetProjectTemplateFolders)
        {
            Write-Verbose "Checking files in $($projectTemplates)\$($targetTemplateFolder)"

            # NOTE(crhodes)
            # This needs to be smarter as files can exist at top level or in a sub folder
            # Usually there is only one matching file in a template
            #
            # Special case for ReadMe.Txt

            if ($masterFile -match "ReadMe.Txt")
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
                elseif ($targetFIle.Count -gt 1)
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

function ProcessProjectFiles()
{
    Write-Verbose "---------- Processsing all commonProjectFiles ----------"
    Write-Verbose ""

    foreach ($masterFile in $commonProjectFiles)
    {
        UpdateMatchingFiles $masterFile
    }

    Write-Verbose "---------- Processing all commonItemFiles ----------"
    Write-Verbose ""

    foreach ($masterFile in $commonItemFiles)
    {
        UpdateMatchingFiles $masterFile
    }    
}

function ProcessItemFiles()
{
    foreach ($masterFile in $commonItemFiles)
    {
        if (Test-Path $sourceMaster\$masterFile)
        {
            $masterFileInfo = Get-ChildItem $sourceMaster\$masterFile
            Write-Verbose "$($masterFile) $($masterFileInfo.LastWriteTime) $($masterFileInfo.Length)"
        
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

ProcessProjectFiles

ProcessItemFiles

if ($masterFileUpdated)
{
    Write-Host "Master file(s) updated.  Propagating changes"
    ProcessProjectFiles
    ProcessItemFiles
}

WriteDelimitedMessage "Synchronization Complete !"
# Read-Host -Prompt "Press Enter to Exit"