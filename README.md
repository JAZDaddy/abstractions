# abstractions
Abstractions is a sample project demonstrating the refinement of a simple calculation engine from a very specific
concrete implementation that adds two doubles into a more flexible, extensible, and maintainable model by introducing
abstractions in the form of _.NET interfaces_.

## Background

The Abstractions solution exists only to demonstrate applying well-chosen abstractions to simplify and streamline development
while allowing code to remain understandable and appropriately extensible. "Architecture astronauts" can go far off the range
developing systems that are infinitely extensible, but ultimately only succeed in making code changes difficult to understand.
This gives "architecture" a bad name, but only due to what amounts to architectural malpractice. Architecture, properly
applied and understood, manages the internal and external forces on the codebase to allow it to remain resilient to the
needs of the business, yet structurally and operationally sound when outside forces (such as unavailability of external 
services or external attack by malicious agents) put pressure on the system. One of the ways we can mitigate the internal
pressures--the need to adapt to changing business needs--is to wall off code that is likely to change behind an abstraction.

This code is intended to demonstrate the realization of code duplication in a simple solution and the progressive refactoring
of this code into a model that allows for more common code and less developer effort in creating new duplicates when adding
functionality, all while maintaining a coding model that is easy to understand and code against.

## Organization

The Abstractions solution is divided into the following projects:

### Abstractions

The read-execute-print loop (REPL) execution harness for the Abstractions classes.

### Abstractions.Common

### Abstractions.FullyConcrete

### Abstractions.MultipleFullyConcrete

### Abstractions.MoreAbstract

## Errata
