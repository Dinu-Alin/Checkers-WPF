# Checkers-WPF

A simple single-player Checkers implementation in WPF using the [Model-View-ViewModel](https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern) Design Pattern.

* VIEW: The View is defined in XAML and does not have any logic in the code-behind. It binds to the view-model by only using data binding.
* MODEL: The Model is responsible for exposing data in a way that is easily consumable by WPF..
* VIEWMODEL: The ViewModel is a model for a view in the application. It exposes data relevant to the view and exposes the behaviors for the views, using proper Commands.
