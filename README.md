# STP Loader

This library is a generic approach to work with `.stp` files in C#.

The ISO 10303 standard contains a wide variety of APs. This library only tries to implement a small subset of this standard to provide a starting point for working with CAD data in game engines like Unity3D.

To accomplish the generic behavior. The STEP data will be converted into an internal representation and can be mapped to another format, if this is neccessary. So this library doesn't rely on an external data representation like Unity3D vectors or such a thing.