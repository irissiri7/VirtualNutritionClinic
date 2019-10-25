# VirtualNutritionClinic

This is a domain model of a "virtual nutrition clinic". The point of the clinic 
is to admit clients with abnormal BMI (Body Mass Index) and help them reach normal
weight.

The clinic consists of four major enteties: a dietitian, a personal trainer, a 
smoothiebar and, of course, the clients. As a user of this domain model, you get 
to decide the interactions between these enteties by multiple different choices 
displayed in the simulation. Every day the clients health is evaluated, if the calories consumed
are less than the calorie need, the client loses weight. If the calories consumed exceed the
calorie need, the client gains weight.
When the client reaches normal weight he/she is discharged and a new client is admited.
If a client drops below BMI 12 he/she is admited to the hospital. 

Two design patterns have been implemented.

First is the "state pattern" which is implemented in the simulation class
to customize the display options. If we are in the "StandardState" or
have decided to go to the smoothiebar (the "SmoothieState") the simulation shifts 
to behave as the smoothiebar.

The second pattern is the "command pattern". This pattern is implemented for the different 
command options in the simulation. Each command is wraped in its own class, 
holding all the information about the command itself. The command classes then 
implement the ICommand interface, declaring an Execute() method for all commands.

Lastly, a set of smaller classes have been constructed to support the major enteties, 
for example the smoothie bar has objects of type smoothie and a smoothie has objects of
type food. Hopefully somewhat self explanatory in the code base.

Well, enjoy!
