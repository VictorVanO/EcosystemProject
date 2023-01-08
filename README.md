# EcosystemProject
2D Ecosystem simulation project made by Van Olffen Victor & Mettioui Mourad

## Simulation
The simulation contains multiples entities. It has animals and plants.
The animals have a gender ("Male" or "Female") and they are either carnivorous or herbivorous. When an animal dies, he becomes meat.
After some time, the animals poop. If the meat is not eaten, it becomes poop. They can fight each other to get food.
Plants feed from the poop and they can create new plants.

## Entities
- Red Circle              : Male Carnivorous Animal
- Pink Circle             : Female Carnivours Animal
- Blue Circle             : Male Herbivorous Animal
- Light Blue Circle       : Female Herbivorous Animal
- Green Circle            : Plant
- Small Indian Red Circle : Meat
- Brown Ellipse           : Poop

## Class Diagram
-
## Sequence Diagram
-
## SOLID Principles

### solid1
-The Open/closed states "software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification";that is, such an entity can allow its behaviour to be extended without modifying its source code.
As you can see below The class Animal has The carnivorous and the herbivorous sub classes 
<picture>
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
<picture>

I can add an other class lets say Nocturnous

As you can see i have succesfully added The Nocturnous class below the heritage of Animal

### solid2
-
