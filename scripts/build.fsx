#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.Core.Target 
nuget Fake.JavaScript.Yarn
nuget Fake.DotNet.Cli //"

#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.DotNet
open System
open Fake.JavaScript

let runAzFunc workingDir args =
    let result =
        Process.execSimple (fun info ->
          { info with
              FileName = "func"
              WorkingDirectory = workingDir
              Arguments = args }) TimeSpan.MaxValue
    if result <> 0 then failwithf "func %s failed" args

let dotnetSdk = DotNet.install DotNet.Release_2_1_300

let clientBuildDir = "../Client/build/"

Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning build directories --- "
  Shell.cleanDir clientBuildDir
  Shell.cleanDir "../Functions/bin"
)

Target.create "BuildClient" (fun _ ->
  Trace.log " --- Building the client app --- "
  Yarn.install (fun o -> { o with WorkingDirectory = "../Client/" })
  Yarn.exec "build" (fun o -> { o with WorkingDirectory = "../Client/" })
)

Target.create "BuildFunctions" (fun _ ->
  Trace.log " --- Building functions app --- "
  DotNet.build (fun p -> {p with Configuration = DotNet.Debug}  ) "../wineventory.sln"
)

Target.create "Run" (fun _ ->
  Trace.log " --- Starting Azure function runtime --- "
  runAzFunc "../Functions/bin/Debug/netstandard2.0/" "start"
)

Target.create "PublishFunctions" (fun _ ->
  Trace.log " --- Publishing functions app --- "
  DotNet.publish (fun p -> p  ) "../functions/functions.csproj"
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)


open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "BuildClient"
  ==> "PublishFunctions"
  ==> "Deploy"

"Clean"
  ==> "BuildClient"
  ==> "BuildFunctions"
  ==> "Run"

// *** Start Build ***
Target.runOrDefault "BuildFunctions"