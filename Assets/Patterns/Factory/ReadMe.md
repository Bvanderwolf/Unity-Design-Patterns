Factory

The goal of the factory pattern is to centralize the creation of an object. This brings
with it the following advantages.

1. An interface or abstract class can be used. This can be returned by the factory instead
of a concrete implementation which allows for addition of multiple implementations and creation
of one of these based on (for example) a configuration.

2. No changes have to be made to code that use this factory. Because this code is talking
to an interface or abstract class, it can rely on the functionality to work.