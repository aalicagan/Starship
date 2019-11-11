## PROBLEM
The application will take as input a distance in mega lights (MGLT).
The output should be a collection of all the star ships and the total amount of stops required to make the distance between the planets.

Sample output for 1000000:
Y-wing: 74
Millennium Falcon: 9
Rebel Transport: 11

## SOLUTION
This console app has developed with .Net Core 3.0. This project also includes 2 nuget packages which are Newtonsoft.Json and Automapper.
The solution utilises the [Star Wars API](as). This provides all the relevant information required to make this calculation.

Calculation: ( MGLT Input by User / ( Starship MGLT * ( Starship Consumables converted to hours) ) ) 

## Instructions
1. When the exe is started, the distance must be entered by the user.This distance must be positive and not bigger than 9223372036854775807.

![](https://github.com/aalicagan/star-wars/blob/master/images/1.PNG)

2. After the distance are entered, the app collects data from Star Wars api page by page.

![](https://github.com/aalicagan/star-wars/blob/master/images/2.PNG)

3. Once data from all star ships are collected, the app calculates how much each star ship needs resupply to reach a planet. and shows the screen. 
The app also shows number of star ships and star ship which needs the biggest resupply freq for the distance. 

![](https://github.com/aalicagan/star-wars/blob/master/images/3.PNG)
