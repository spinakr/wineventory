#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.Core.Target 
nuget Fake.JavaScript.Yarn //"

#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.JavaScript

let clientBuildDir = "./src/Client/build/"

Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning build directories --- "
  Shell.cleanDir clientBuildDir
)

Target.create "BuildClient" (fun _ ->
  Trace.log " --- Building the client app --- "
  Yarn.install (fun o -> { o with WorkingDirectory = "./src/Client/" })
  Yarn.exec "build" (fun o -> { o with WorkingDirectory = "./src/Client/" })
)

Target.create "BuildFunctions" (fun _ ->
  Trace.log " --- Building the client app --- "
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "BuildClient"
  ==> "BuildFunctions"
  ==> "Deploy"

// *** Start Build ***
Target.runOrDefault "BuildFunctions"