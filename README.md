# EcosystemProject
2D Ecosystem simulation project made by Van Olffen Victor & Mettioui Mourad

## Simulation
The simulation contains multiples entities. It has animals and plants.
The animals have a gender ("Male" or "Female") and they are either carnivorous or herbivorous. When an animal dies, he becomes meat.
After some time, the animals poop. If the meat is not eaten, it becomes poop. They can fight each other to get food.

The animals and plants have energy. They lose energy over time and if their energy bar is empty, they lose health to refill it.
To refill their health, they have to eat.

When the animals and plants have no remaining health, they die and disappear from the simulation.

The animals can reproduce if there is a male and a female.
Plants feed from the poop so they can create new plants.

## Entities
- Red Circle              : Male Carnivorous Animal
- Pink Circle             : Female Carnivours Animal
- Blue Circle             : Male Herbivorous Animal
- Light Blue Circle       : Female Herbivorous Animal
- Green Circle            : Plant
- Small Indian Red Circle : Meat
- Brown Ellipse           : Poop

## Class Diagram
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/ClassDiagram.png">
</picture>

## Sequence Diagram
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/SequenceDiagram.png">
</picture>

## SOLID Principles

### Lyskov Substitution Principle
-The Lyskov Substitution principle protocol defines a notion of substitutability for objects; that is, if S is a subtype of T, then objects of type T in a program may be replaced with objects of type S without altering any of the desirable properties of that program.
Ideed we can see below the attributes Radius and Ready of the "T" class SimulationObject
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S1_attributes.PNG">
<picture>
  
then we know that Animal is a subtype of SimulationObject
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S1_legacy.PNG">
<picture>
  
We can see that Animal uses and changes the attributes values without going on the SimulationObject class
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S1_using.PNG">
<picture>
  
and here
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S1_using2.PNG">
<picture>

### Open/Closed Principle
-The Open/closed states "software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification";that is, such an entity can allow its behaviour to be extended without modifying its source code.
As you can see below The class Animal has The carnivorous and the herbivorous sub classes
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S2_Files%20before.PNG">
<picture>

I can add an other class lets say Nocturnous
<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S2_Added%20Class.PNG">
<picture>

As you can see i have succesfully added The Nocturnous class below the heritage of Animal

<picture>
  <img src="https://github.com/VictorVanO/EcosystemProject/blob/main/images%20project/S2_Files%20after.PNG">
<picture>
