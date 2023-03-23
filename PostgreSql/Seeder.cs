public static class Seeder
{
    public static async Task Seed(this FamilyTreeContext context)
    {
        await context.AddRangeAsync(
            new Halfling(new LTree(""), "Balbo", 1167),
            new Halfling(new LTree("1"), "Mungo", 1207),
            new Halfling(new LTree("2"), "Pansy", 1212),
            new Halfling(new LTree("3"), "Ponto", 1216),
            new Halfling(new LTree("4"), "Largo", 1220),
            new Halfling(new LTree("5"), "Lily", 1222),
            new Halfling(new LTree("1.1"), "Bungo", 1246),
            new Halfling(new LTree("1.2"), "Belba", 1256),
            new Halfling(new LTree("1.3"), "Longo", 1260),
            new Halfling(new LTree("1.4"), "Linda", 1262),
            new Halfling(new LTree("1.5"), "Bingo", 1264),
            new Halfling(new LTree("3.1"), "Rosa", 1256),
            new Halfling(new LTree("3.2"), "Polo"),
            new Halfling(new LTree("4.1"), "Fosco", 1264),
            new Halfling(new LTree("1.1.1"), "Bilbo", 1290),
            new Halfling(new LTree("1.3.1"), "Otho", 1310),
            new Halfling(new LTree("1.5.1"), "Falco", 1303),
            new Halfling(new LTree("3.2.1"), "Posco", 1302),
            new Halfling(new LTree("3.2.2"), "Prisca", 1306),
            new Halfling(new LTree("4.1.1"), "Dora", 1302),
            new Halfling(new LTree("4.1.2"), "Drogo", 1308),
            new Halfling(new LTree("4.1.3"), "Dudo", 1311),
            new Halfling(new LTree("1.3.1.1"), "Lotho", 1310),
            new Halfling(new LTree("1.5.1.1"), "Poppy", 1344),
            new Halfling(new LTree("3.2.1.1"), "Ponto", 1346),
            new Halfling(new LTree("3.2.1.2"), "Porto", 1348),
            new Halfling(new LTree("3.2.1.3"), "Peony", 1350),
            new Halfling(new LTree("4.1.2.1"), "Frodo", 1368),
            new Halfling(new LTree("4.1.3.1"), "Daisy", 1350),
            new Halfling(new LTree("3.2.1.1.1"), "Angelica", 1381));

        await context.SaveChangesAsync();
    }
    
    public static async Task Seed(this InterestsContext context)
    {
        await context.AddRangeAsync(
            new Interest("Top"),
            new Interest("Top.Science"),
            new Interest("Top.Science.Astronomy"),
            new Interest("Top.Science.Astronomy.Astrophysics"),
            new Interest("Top.Science.Astronomy.Cosmology"),
            new Interest("Top.Hobbies"),
            new Interest("Top.Hobbies.Amateurs_Astronomy"),
            new Interest("Top.Collections"),
            new Interest("Top.Collections.Pictures"),
            new Interest("Top.Collections.Pictures.Astronomy"),
            new Interest("Top.Collections.Pictures.Astronomy.Stars"),
            new Interest("Top.Collections.Pictures.Astronomy.Galaxies"),
            new Interest("Top.Collections.Pictures.Astronomy.Astronauts"));

        await context.SaveChangesAsync();
    }
}