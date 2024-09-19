# BoldBI Embedding Xamarin Sample

This Bold BI Xamarin sample repository contains the Dashboard embedding sample. This sample demonstrates how to embed the dashboard which is available in your Bold BI server.

This section guides you in using the Bold BI dashboard in your Xamarin sample application.

* [Requirements to run the demo](#requirements-to-run-the-demo)
* [Using the Xamarin sample](#using-the-xamarin-sample)
* [Online Demos](#online-demos)
* [Documentation](#documentation)

## Requirements to run the demo

The samples require the following to run:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)

## Using the Xamarin sample

* Open the Xamarin embed sample in Visual Studio.

* Open the `EmbedProperties.cs` file and change the following properties in the file as per your Bold BI Server.

| Parameter         | Description                                                                                                                                                   |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **RootUrl**      | Dashboard Server URL (e.g., `http://localhost:5000/bi`, `http://demo.boldbi.com/bi`).                                                                          |
| **SiteIdentifier** | For the Bold BI Enterprise edition, it should be like `site/site1`. For Bold BI Cloud, it should be an empty string.                                         |
| **Environment**  | Your Bold BI application environment. (If Cloud, you should use `cloud`; if Enterprise, you should use `enterprise`).                                          |
| **UserEmail**    | UserEmail of the Admin in your Bold BI, which will be used to get the dashboard list.                                                                          |
| **EmbedSecret**  | Get your EmbedSecret key from the Embed tab by enabling the `Enable embed authentication` on the [Administration page](https://help.boldbi.com/embedded-bi/site-administration/embed-settings/?utm_source=github&utm_medium=backlinks). |
| **dashboardId**  | Id of the dashboard you want to embed.                                                                                                                         |

* Now run the Xamarin sample by using the following command.

Please refer to the [help documentation](https://help.boldbi.com/embedded-bi/javascript-based/samples/v3.3.40-or-later/xamarin/#how-to-run-the-sample?utm_source=github&utm_medium=backlinks) to know how to run the sample.

## Online Demos

Look at the Bold BI Embedding sample to live demo [here](https://samples.boldbi.com/embed?utm_source=github&utm_medium=backlinks).

## Documentation

A complete Bold BI Embedding documentation can be found on [Bold BI Embedding Help](https://help.boldbi.com/embedded-bi/javascript-based/?utm_source=github&utm_medium=backlinks).
