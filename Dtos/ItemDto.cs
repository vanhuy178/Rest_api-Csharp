using System;
namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; } // init only properties, instead "private set;"
                                      // You can do this
                                      // Item item = new Item() {Id = Guid.NewGuid()};
                                      // But not this 
                                      // item.Id = Guid.NewGuid();

        // What is Guid ?
        /* 
            // Create and display the value of two GUIDs.
            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
            Console.WriteLine(Guid.NewGuid());

            // This code example produces a result similar to the following:

            // 0f8fad5b-d9cb-469f-a165-70867728950e
            // 7c9e6679-7425-40de-944b-e07fc1f90ae7
        */

        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}