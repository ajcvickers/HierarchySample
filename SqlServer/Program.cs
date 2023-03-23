await using var context = new FamilyTreeContext();

await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await context.Seed();
context.ChangeTracker.Clear();
Console.WriteLine();

// // Find a generation
// var level = 2;
// var halflingGeneration = await context.Halflings
//     .Where(h => h.PathFromPatriarch.GetLevel() == level)
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Generation {level}: {string.Join(", ", halflingGeneration.Select(e => e.Name))}");

// // Find all generations
// var halflingGenerations = await context.Halflings
//     .GroupBy(h => h.PathFromPatriarch.GetLevel())
//     .ToListAsync();
//
// Console.WriteLine();
// foreach (var group in halflingGenerations)
// {
//     Console.WriteLine($"Generation {group.Key}: {string.Join(", ", group.Select(e => e.Name))}");
// }

// // Find all descendents
// var name = "Mungo";
// var descendents = await context.Halflings.Where(
//         h1 => h1.PathFromPatriarch.IsDescendantOf(
//             context.Halflings.Single(h2 => h2.Name == name && h1.Id != h2.Id).PathFromPatriarch))
//     .ToListAsync();
//     
// Console.WriteLine();
// Console.WriteLine($"All descendents of {name}: {string.Join(", ", descendents.Select(e => e.Name))}");

// // Find all ancestors
// var name = "Longo";
// var ancestors = await context.Halflings.Where(
//         h1 => context.Halflings.Single(h2 => h2.Name == name && h1.Id != h2.Id).PathFromPatriarch
//             .IsDescendantOf(h1.PathFromPatriarch))
//     .ToListAsync();
//     
// Console.WriteLine();
// Console.WriteLine($"All ancestors of {name}: {string.Join(", ", ancestors.Select(e => e.Name))}");

// // Find direct descendents
// var name = "Mungo";
// var directDescendents = await context.Halflings
//     .Where(h1 => h1.PathFromPatriarch.GetAncestor(1) == context.Halflings
//         .Single(h2 => h2.Name == name).PathFromPatriarch)
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Direct descendents of {name}: {string.Join(", ", directDescendents.Select(e => e.Name))}");

// // Find direct ancestor
// var name = "Bilbo";
// var directAncestor = await context.Halflings
//     .SingleOrDefaultAsync(
//         h1 => h1.PathFromPatriarch == context.Halflings
//             .Single(h2 => h2.Name == name).PathFromPatriarch.GetAncestor(1));
//
// Console.WriteLine();
// Console.WriteLine($"The direct ancestor of {name} is {directAncestor?.Name}");

// Find closest common ancestor
var halfling1 = await context.Halflings.SingleAsync(halfling => halfling.Name == "Frodo");
var halfling2 = await context.Halflings.SingleAsync(halfling => halfling.Name == "Bilbo");

var commonAncestor = await context.Halflings
    .Where(h => halfling1.PathFromPatriarch.IsDescendantOf(h.PathFromPatriarch)
                && halfling2.PathFromPatriarch.IsDescendantOf(h.PathFromPatriarch))
    .OrderByDescending(h => h.PathFromPatriarch.GetLevel())
    .FirstOrDefaultAsync(); 

Console.WriteLine();
Console.WriteLine($"The common ancestor of {halfling1.Name} and {halfling2.Name} is {commonAncestor?.Name}");
