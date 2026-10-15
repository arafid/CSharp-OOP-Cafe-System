# C# OOP Cafe Ordering System

A C# console application that models a cafe ordering workflow using object-oriented programming. The project represents different drink types, employees, customers, pricing, preparation steps, loyalty points, and payment behavior through related classes.

## Core OOP Design

The application uses a base `Drink` class with specialized subclasses including:

- `Coffee`
- `Tea`
- `Juice`
- `Smoothie`
- `SeasonalSpecial`

Additional `Employee` and `Customer` classes model ordering, preparation, purchases, wallet balance, loyalty points, and payment processing.

## Concepts Demonstrated

- classes and objects
- inheritance
- method overriding and virtual methods
- encapsulation with private and protected fields
- polymorphic behavior through the `Drink` base class
- type checking and subclass-specific preparation logic
- constructors and object initialization
- `List<T>` collections
- pricing, discounts, and state changes

## Example Workflow

```text
Employee receives order
        ↓
Creates the appropriate Drink subclass
        ↓
Customer purchases the item
        ↓
Employee prepares it using type-specific behavior
        ↓
Customer bag and total are calculated
        ↓
Payment is processed
```

## Tech

- C#
- .NET
- Visual Studio
- Object-Oriented Programming

## Run the Project

Open the solution in Visual Studio and run the console application, or run it from the project directory with:

```bash
dotnet run
```

## Skills Demonstrated

`C#` · `.NET` · `OOP` · `Inheritance` · `Polymorphism` · `Encapsulation` · `Collections`

## Project Note

This project was originally developed as a programming course assignment and is retained as a portfolio example of object-oriented application design in C#.
