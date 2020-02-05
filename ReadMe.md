# Learning MVVMLight

This app is a way for me to explore the use of MVVM Light.

## Thoughts on Composition

For my first task, I'm making a master detail view. 

The master will have an item collection of buttons that show items from an observable collection of view models. 

To show the detail view when an item button is clicked, I'll bind each button to a command that sends the id of the view model via a message.

I'm waffling on whether to send the entire view model because I haven't yet made a service to provide data for the events. 

If I did that I could get an event by id in any of the view models that need it.

