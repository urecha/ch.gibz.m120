# M120 Projekt Ticket-Bestellsystem by Urech Andrin

## Overview

The project is implemented according to the specifications in *M120_Projekt_Auftrag.pdf*.
It consists of an WPF MVVM appliation with two windows allowing a user to see a cinema's films and order tickets for them.

## Ergonomy standards implementation

| Standard | Measure(s) | Implementation |
| --- | --- | --- |
| Conformity to expectations | The windows are structured in a well established way, which should conform to the user's expectations and minimize the learning needed. | The window-header consits of a summary of informations telling the user where he is, what he's doing ("navigation" on the right) and what the object of interest is (Cinema's name on `OverviewWindow`, Film-Summary on `OrderWindow`.The searchbar in the `OverviewWindow` is placed on top of the searchable list, labelled with a known icon and searches are effectuated on the Film's title, as one would expect. The dialog in the `OrderWindow` has its steps going from left to right. All as the user should know it from countless other user interfaces.|
| Error tolerance | User input is minimized and where possible, it is monitored and assists the user in not making invalid inputs. | The film-search field can contain anything a film title can contain. Therefore it is not restricted. The only other input is in the `OrderWindow`, where a user can indicate how many tickets they would like to order. This input only allows numeric values by assigning an event-handler to the `PreviewTextInput` event, which checks whether the input is numeric via RegEx match. On top of that, it does not allow negative values (by not allowing the "-" sign, but also with a fallback defined in the respective setter) and will set the input value down to the max available tickets in case this amount is exceeded by the user input (would also set it to 0 if the value would attempt to fall below that). | 
| Self-descriveness | The app's one hand got a quite small scope, so not much explaining needs to be done in any case, on the other hand some measures are consciously taken to guarantee self-descriptiveness: Title-/Nav-bar, coherent highlighting, feedback. | Both windows have a header with a pseudo-navigation, which describes what window the user's on (right side of the header) and what the object of interest is (cinema or film-summary).The "Order tickets" button activates only once a film is selected and is then highlighted in the same color as the selected film. This makes it clear, that "Order tickets" will order for the selected film. After ordering tickets, a confirmation summarizing the order is shown.gith
