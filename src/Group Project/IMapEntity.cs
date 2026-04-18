using System;
using System.Collections.Generic;
using System.Linq;

/*
Interface for map entities.
Any entity that is placed on a tile must implement this interface
This design allows for polymorphism when placing entities on tiles, as all
entities will have a name property that can be accessed regardless of
their specific type ( Enemy, NPC, Item, etc.)

This was made with the intention of replacing the string-match lookup for the FindX() functions
This way, a tile can hold a direct reference to the entity it contains.

 */


namespace Group_Project
{
    public interface IMapEntity
    {
        string Name { get; }
    }
}
