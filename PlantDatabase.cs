using PlantCareApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace PlantCareApp
{

    public class PlantDatabase
    {
        public List<PlantCardViewModel> Plants { get; set; }

        public PlantDatabase()
        {
            Plants = new List<PlantCardViewModel>();
        }

        public void AddPlant(PlantCardViewModel plant)
        {
            Plants.Add(plant);
        }


        public void FillDatabase()
        {
            
            this.AddPlant(new PlantCardViewModel("Ficus", "Ficus elastica", "Bright indirect light", "Once a week", "../../../Images/ficus.png", "A popular indoor plant with large, glossy leaves."));
            this.AddPlant(new PlantCardViewModel("Snake Plant", "Sansevieria trifasciata", "Low light", "Every 2 weeks", "../../../Images/snakeplant.jpg", "A hardy plant that thrives on neglect."));
            this.AddPlant(new PlantCardViewModel("Aloe Vera", "Aloe barbadensis miller", "Bright, indirect light", "Every 2-3 weeks", "../../../Images/aloe.jpg", "A succulent plant known for its healing properties."));
            this.AddPlant(new PlantCardViewModel("Peace Lily", "Spathiphyllum", "Low to bright indirect light", "Once a week", "../../../Images/peacelily.jpg", "A beautiful flowering plant with air-purifying qualities."));
            this.AddPlant(new PlantCardViewModel("Spider Plant", "Chlorophytum comosum", "Bright, indirect light", "Once a week", "../../../Images/spiderplant.jpg", "A resilient plant that produces baby plants on long stems."));
            this.AddPlant(new PlantCardViewModel("ZZ Plant", "Zamioculcas zamiifolia", "Low to bright indirect light", "Once every 2-3 weeks", "zzplant.png", "An easy-to-care-for plant with waxy, glossy leaves."));
            this.AddPlant(new PlantCardViewModel("Pothos", "Epipremnum aureum", "Low to bright indirect light", "Once a week", "pothos.png", "A trailing plant with heart-shaped leaves that is easy to grow."));
            this.AddPlant(new PlantCardViewModel("Cactus", "Cactaceae", "Direct sunlight", "Every 2-3 weeks", "cactus.png", "A desert plant known for its ability to store water."));
            this.AddPlant(new PlantCardViewModel("Succulent", "Various species", "Bright, indirect light", "Once every 2 weeks", "succulent.png", "A group of plants known for storing water in their leaves."));
            this.AddPlant(new PlantCardViewModel("Monstera", "Monstera deliciosa", "Bright, indirect light", "Once a week", "monstera.png", "A tropical plant with large, perforated leaves."));
            this.AddPlant(new PlantCardViewModel("Fiddle Leaf Fig", "Ficus lyrata", "Bright, indirect light", "Once a week", "fiddleleaffig.png", "A popular indoor tree with large, violin-shaped leaves."));
            this.AddPlant(new PlantCardViewModel("English Ivy", "Hedera helix", "Low to moderate light", "Once a week", "englishivy.png", "A climbing vine with green leaves, often used in hanging baskets."));
            this.AddPlant(new PlantCardViewModel("Dracaena", "Dracaena spp.", "Indirect light", "Once a week", "dracaena.png", "A group of plants known for their long, sword-shaped leaves."));
            this.AddPlant(new PlantCardViewModel("Begonia", "Begonia spp.", "Indirect light", "Once a week", "begonia.png", "A flowering plant with decorative foliage."));
            this.AddPlant(new PlantCardViewModel("Aloe Vera", "Aloe barbadensis miller", "Bright, indirect light", "Once every 2-3 weeks", "aloe2.png", "A succulent with medicinal properties."));
            this.AddPlant(new PlantCardViewModel("Bamboo Palm", "Chamaedorea seifrizii", "Low to moderate light", "Once a week", "bamboopalm.png", "A palm plant that grows well in low light."));
            this.AddPlant(new PlantCardViewModel("Areca Palm", "Dypsis lutescens", "Bright, indirect light", "Once a week", "arecapalm.png", "A popular indoor palm known for its feathery fronds."));
            this.AddPlant(new PlantCardViewModel("Lavender", "Lavandula spp.", "Full sunlight", "Once a week", "lavender.png", "A fragrant herb that blooms with purple flowers."));
            this.AddPlant(new PlantCardViewModel("Mint", "Mentha spp.", "Indirect light", "Once a week", "mint.png", "A fragrant herb commonly used in cooking and teas."));
            this.AddPlant(new PlantCardViewModel("Chili Pepper", "Capsicum annuum", "Full sunlight", "Once a week", "chilipepper.png", "A small plant known for its spicy fruits."));
            this.AddPlant(new PlantCardViewModel("Basil", "Ocimum basilicum", "Full sunlight", "Once a week", "basil.png", "A fragrant herb often used in cooking."));
            this.AddPlant(new PlantCardViewModel("Tomato", "Solanum lycopersicum", "Full sunlight", "Every 2-3 days", "tomato.png", "A popular vegetable that thrives in direct sunlight."));
            this.AddPlant(new PlantCardViewModel("Lemon Balm", "Melissa officinalis", "Partial sunlight", "Once a week", "lemonbalm.png", "A fragrant herb with a lemon scent."));
            this.AddPlant(new PlantCardViewModel("Rosemary", "Rosmarinus officinalis", "Full sunlight", "Once a week", "rosemary.png", "A woody herb used in cooking with a fragrant aroma."));
            this.AddPlant(new PlantCardViewModel("Thyme", "Thymus vulgaris", "Full sunlight", "Once a week", "thyme.png", "A small, aromatic herb used in many dishes."));
            this.AddPlant(new PlantCardViewModel("Lemon Tree", "Citrus limon", "Full sunlight", "Every 2-3 days", "lemontree.png", "A small tree that produces sour lemons."));
            this.AddPlant(new PlantCardViewModel("Apple Tree", "Malus domestica", "Full sunlight", "Once a week", "appletree.png", "A fruit tree that produces apples."));
            this.AddPlant(new PlantCardViewModel("Peach Tree", "Prunus persica", "Full sunlight", "Once a week", "peachtree.png", "A fruit tree known for its juicy peaches."));
            this.AddPlant(new PlantCardViewModel("Fig Tree", "Ficus carica", "Full sunlight", "Once a week", "figtree.png", "A tree that produces sweet, edible figs."));
            this.AddPlant(new PlantCardViewModel("Plum Tree", "Prunus domestica", "Full sunlight", "Once a week", "plumtree.png", "A fruit tree known for its purple or red plums."));
            this.AddPlant(new PlantCardViewModel("Olive Tree", "Olea europaea", "Full sunlight", "Once a week", "olivetree.png", "A tree that produces olives, used for oil."));
            this.AddPlant(new PlantCardViewModel("Cherry Tree", "Prunus avium", "Full sunlight", "Once a week", "cherrytree.png", "A tree that produces sweet, edible cherries."));
            this.AddPlant(new PlantCardViewModel("Grape Vine", "Vitis vinifera", "Full sunlight", "Once a week", "grapevine.png", "A vine that produces clusters of grapes."));
            this.AddPlant(new PlantCardViewModel("Strawberry Plant", "Fragaria × ananassa", "Full sunlight", "Once a week", "strawberry.png", "A plant that produces sweet, red strawberries."));
            this.AddPlant(new PlantCardViewModel("Raspberry Plant", "Rubus idaeus", "Full sunlight", "Once a week", "raspberry.png", "A plant that produces sweet, red raspberries."));
            this.AddPlant(new PlantCardViewModel("Blueberry Bush", "Vaccinium spp.", "Full sunlight", "Once a week", "blueberry.png", "A bush that produces sweet, blue blueberries."));
            this.AddPlant(new PlantCardViewModel("Goji Berry", "Lycium barbarum", "Full sunlight", "Once a week", "gojiberry.png", "A plant known for its red, superfood berries."));
            this.AddPlant(new PlantCardViewModel("Blackberry Bush", "Rubus fruticosus", "Full sunlight", "Once a week", "blackberry.png", "A bush that produces sweet, blackberries."));
            this.AddPlant(new PlantCardViewModel("Cucumber", "Cucumis sativus", "Full sunlight", "Once a week", "cucumber.png", "A vine plant that produces green cucumbers."));
            this.AddPlant(new PlantCardViewModel("Zucchini", "Cucurbita pepo", "Full sunlight", "Once a week", "zucchini.png", "A plant that produces tender, edible zucchinis."));
            this.AddPlant(new PlantCardViewModel("Squash", "Cucurbita spp.", "Full sunlight", "Once a week", "squash.png", "A plant that produces a variety of squash types."));
            this.AddPlant(new PlantCardViewModel("Pumpkin", "Cucurbita pepo", "Full sunlight", "Once a week", "pumpkin.png", "A vine plant that produces large pumpkins."));
            this.AddPlant(new PlantCardViewModel("Melon", "Cucumis spp.", "Full sunlight", "Once a week", "melon.png", "A plant that produces sweet melons."));
            this.AddPlant(new PlantCardViewModel("Watermelon", "Citrullus lanatus", "Full sunlight", "Once a week", "watermelon.png", "A plant that produces large, sweet watermelons."));
            this.AddPlant(new PlantCardViewModel("Carrot", "Daucus carota", "Full sunlight", "Once a week", "carrot.png", "A root vegetable known for its orange color."));
            this.AddPlant(new PlantCardViewModel("Lettuce", "Lactuca sativa", "Full sunlight", "Once a week", "lettuce.png", "A leafy vegetable often used in salads."));
            this.AddPlant(new PlantCardViewModel("Spinach", "Spinacia oleracea", "Full sunlight", "Once a week", "spinach.png", "A leafy green vegetable high in iron."));


        }
    }
}
