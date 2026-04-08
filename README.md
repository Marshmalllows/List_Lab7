# Lab 7 — Singly Linked List

Lab work from **Programming Essentials: Part 2** (1st year, 2nd semester, 2024).

## Description

A console application implementing a singly linked list of `float` values with the following operations:

1. **Add element** — inserts after the second element (if at least two exist), otherwise appends to the end
2. **Find first value > 2x** — finds the first element in the list that is greater than twice the given value
3. **Count values > 3.14** — counts how many elements exceed pi
4. **Create filtered list** — builds a new list containing only elements greater than a given value
5. **Delete above average** — removes all elements whose value exceeds the list's average

The program supports managing multiple named lists through an interactive console menu.

## Tech Stack

- C# / .NET 8.0

## How to Run

```bash
dotnet run --project list
```