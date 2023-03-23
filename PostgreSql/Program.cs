await using var context = new FamilyTreeContext();

await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await context.Seed();
context.ChangeTracker.Clear();
Console.WriteLine();

// // Find a generations
// var level = 2;
// var halflingGeneration = await context.Halflings
//     .Where(h => h.PathFromPatriarch.NLevel == level)
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Generation {level}: {string.Join(", ", halflingGeneration.Select(e => e.Name))}");

// // Find all generations
// var halflingGenerations = await context.Halflings
//     .GroupBy(h => h.PathFromPatriarch.NLevel)
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
//         h1 => h1.PathFromPatriarch.IsAncestorOf(
//             context.Halflings.Single(h2 => h2.Name == name && h1.Id != h2.Id).PathFromPatriarch))
//     .ToListAsync();
//     
// Console.WriteLine();
// Console.WriteLine($"All ancestors of {name}: {string.Join(", ", ancestors.Select(e => e.Name))}");

// // Find direct descendents
// var name = "Mungo";
// var directDescendents = await context.Halflings.Where(
//         h1 => h1.PathFromPatriarch.IsDescendantOf(
//             context.Halflings.Single(
//                     h2 => h2.Name == name
//                           && h1.PathFromPatriarch.NLevel == h2.PathFromPatriarch.NLevel + 1)
//                 .PathFromPatriarch))
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Direct descendents of {name}: {string.Join(", ", directDescendents.Select(e => e.Name))}");

// // Find direct ancestor
// var name = "Bilbo";
// var directAncestor = await context.Halflings.SingleOrDefaultAsync(
//     h1 => h1.PathFromPatriarch.IsAncestorOf(
//         context.Halflings.Single(
//             h2 => h2.Name == name
//                   && h1.PathFromPatriarch.NLevel == h2.PathFromPatriarch.NLevel - 1).PathFromPatriarch));
//
// Console.WriteLine();
// Console.WriteLine($"The direct ancestor of {name} is {directAncestor?.Name}");

// // Find direct ancestor 2
// var name = "Bilbo";
// var directAncestor = await context.Halflings
//     .SingleOrDefaultAsync(
//         h1 => h1.PathFromPatriarch == context.Halflings
//             .Single(h2 => h2.Name == name).PathFromPatriarch.Subpath(0, -1));
//
// Console.WriteLine();
// Console.WriteLine($"The direct ancestor of {name} is {directAncestor?.Name}");

// // Find direct descendents 2
// var name = "Mungo";
// var directDescendents = await context.Halflings
//     .Where(h1 => h1.PathFromPatriarch.NLevel > 0 && h1.PathFromPatriarch.Subpath(0, -1) == context.Halflings
//         .Single(h2 => h2.Name == name).PathFromPatriarch)
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Direct descendents of {name}: {string.Join(", ", directDescendents.Select(e => e.Name))}");

// // Find closest common ancestor
// var halfling1 = await context.Halflings.SingleAsync(halfling => halfling.Name == "Angelica");
// var halfling2 = await context.Halflings.SingleAsync(halfling => halfling.Name == "Prisca");
//
// var commonAncestor = await context.Halflings
//     .Where(e => e.PathFromPatriarch ==
//                 context.Halflings.Where(e => e.Name == halfling1.Name)
//                     .SelectMany(h1 => context.Halflings.Where(e => e.Name == halfling2.Name),
//                         (h1, h2) => LTree.LongestCommonAncestor(h1.PathFromPatriarch, h2.PathFromPatriarch))
//                     .SingleOrDefault())
//     .SingleOrDefaultAsync();
//
// Console.WriteLine();
// Console.WriteLine($"The common ancestor of {halfling1.Name} and {halfling2.Name} is {commonAncestor?.Name}");

// // Pattern matching
// var pattern = "*.!pictures@.Astronomy.*";
// var interests = await context.Interests
//     .Where(e => e.Id.MatchesLQuery(pattern))
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Matches for '{pattern}':");
// Console.WriteLine("  " + string.Join(Environment.NewLine + "  ", interests.Select(e => e.Id)));

// // Full text search
// var text = "Astro*% & !pictures@"; // "Astro* & !pictures@";
// var interests = await context.Interests
//     .Where(e => e.Id.MatchesLTxtQuery(text))
//     .ToListAsync();
//
// Console.WriteLine();
// Console.WriteLine($"Matches for '{text}':");
// Console.WriteLine("  " + string.Join(Environment.NewLine + "  ", interests.Select(e => e.Id)));
