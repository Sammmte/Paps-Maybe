# Paps Maybe

Maybe monads for c#.

### Including this package on your Unity Project

Open the "Packages" folder inside your project folder. Open the manifest.json, you should have something like this:

```json
{
   "dependencies": {
        "com.unity.some-package" : "1.0.0",
        "com.unity.some-other-package" : "1.0.0"
        //other packages...
    }
}
```

This "dependencies" json object represents the package key values (key: package name, value: package version) of all packages your project depends on.

First you need to add a "scopedRegistries" json object with the following data:

```json
"scopedRegistries": [
    {
      "name": "Any name should fit",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "paps"
      ]
    }
  ]
```

The "url" field represents the url where Paps CORE packages is hosted.

the "scopes" field represents the permitted package "namespaces". For example if you want to use two packages with names "pepe.awesome-feature" and "pepe.fantastic-feature", you could write both names in the "scopes" object, or simply write "pepe".

For more information about adding custom packages to your unity project, [read unity's documentation here](https://docs.unity3d.com/Manual/CustomPackages.html). Aaaand [here](https://docs.unity3d.com/Manual/upm-manifestPkg.html)

Finally you must add this package dependency to your project in the "dependencies" object:

```json
{
    "dependencies": {
        "com.unity.some-package" : "1.0.0",
        "com.unity.some-other-package" : "1.0.0",
        "paps" : "1.0.0-unity" //other the version you want
      }
}
```

Your manifest.json file should look like this:

```json
{
  "scopedRegistries": [
    {
      "name": "Any name should fit",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "paps"
      ]
    }
  ],

  "dependencies": {
    "com.unity.some-package" : "1.0.0",
    "com.unity.some-other-package" : "1.0.0",
    "paps.fsm": "1.0.0-unity" //other the version you want
  }
}
```