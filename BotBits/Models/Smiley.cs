namespace BotBits
{

    public enum SmileyShape
    {
        Regular = 0,

        Square = 1,

        [Pack("pro")]
        Devil = 2,

        [Pack("smileyshapeegg")]
        Egg = 3,

        [Pack("smileyshaperaindrop")]
        Raindrop = 4,

        [Pack("smileyshapeghost")]
        Ghost = 5,

        [Pack("smileyshapeskull")]
        Skull = 6,
    }

    public enum SmileyBorder
    {
        White = 0,

        [Pack("-", GoldMembershipItem = true)]
        Gold = 1,

        [Pack("-", GoldMembershipItem = true)]
        GoldClassic = 3,

        [Pack("smileyborderfishbowl")]
        FishBowl = 2,

        [Pack("smileyborderred")]
        Red = 4,

        [Pack("smileybordergreen")]
        Green = 5,
    }
    public enum SmileyColour
    {
        Yellow = 0,
        Red = 1,
        [Pack("smileycolourrain")]
        Rain = 2,

        [Pack("smileycolourwhite")]
        White = 3,

        [Pack("smileycolourblack")]
        Black = 4,

        [Pack("-", GoldMembershipItem = true)]
        Gold = 5,

        [Pack("smileycolourterminator")]
        Terminator = 6,

        [Pack("-")]
        Zombie = 7,

        [Pack("smileycolourpurple")]
        Purple = 8,

        [Pack("smileycolourmetal")]
        Metal = 9,

        [Pack("smileycolourghost")]
        Ghost = 10,

        [Pack("smileycolourpenguin")]
        Penguin = 11,

        [Pack("-")]
        Diamond = 12,

        [Pack("-")]
        Hologram = 13,

        [Pack("smileycolourgreen")]
        Green = 14,
    }

    public enum SmileyEyes
    {
        [Pack("smileyeyes3d")]
        _3DGlasses = 0,


        Angry = 1,

        [Pack("smileyeyesconfused")]
        Confused = 2,

        [Pack("pro")]
        Crying = 3,

        [Pack("smileyeyescyclops")]
        Cyclops = 4,

        [Pack("smileyeyesgoofy")]
        Goofy = 5,


        Happy = 6,

        [Pack("smileyeyesmonocle")]
        Monocle = 7,

        [Pack("smileyeyesnerd")]
        NerdGlasses = 8,


        Neutral = 9,

        [Pack("smileyeyesred")]
        Red = 10,

        [Pack("smileyeyesrobber")]
        RobberMask = 11,


        Sad = 12,

        [Pack("pro")]
        Sunglasses = 13,

        [Pack("smileyeyesterminator")]
        Terminator = 14,


        TightlyClosed = 15,

        [Pack("smileyeyestired")]
        Tired = 16,

        Wink = 17,
        Coy = 18,
        LOL = 19,
    }
    public enum SmileyMouth
    {
        BullyFlat = 0,

        [Pack("smileymouthbeak")]
        Beak = 1,

        [Pack("smileymouthbeak2")]
        Beak2 = 2,

        [Pack("smileymouthbunny")]
        BunnyTeeth = 3,

        [Pack("smileymouthcat")]
        Cat = 4,

        [Pack("pro")]
        Cool = 5,


        Flat = 6,
        Frown = 7,

        [Pack("smileymouthgoofy")]
        Goofy = 8,


        Grin = 9,
        Indifferent = 10,

        [Pack("smileymouthkiss")]
        KissyLips = 11,

        [Pack("smileymouthmexican")]
        MexicanMoustache = 12,


        Ooh = 13,

        [Pack("smileymouthpirate")]
        PirateTeeth = 14,

        [Pack("smileymouthrobot")]
        RobotMouth = 15,

        [Pack("smileymouthscared")]
        Scared = 16,

        [Pack("smileymouthsick")]
        Sick = 17,

        Smile = 18,

        [Pack("smileymouthmask")]
        FaceMask = 19,


        Tongue = 20,

        [Pack("smileymouthunsure")]
        Unsure = 21,

        [Pack("smileymouthunsurer")]
        Unsurer = 22,

        [Pack("smileymouthuwu")]
        UwU = 23,

        [Pack("smileymouthwizard")]
        WizardBuckTeeth = 24,

        Coy = 25,
        LOL = 26,
    }
    public enum SmileyAddon
    {
        Nothing = 0,

        [Pack("smileyaddonblood")]
        Blood = 1,

        Blush = 2,
        [Pack("smileyaddonheavyblush")]
        HeavyBlush = 3,

        [Pack("smileyaddonscar")]
        Scar = 4,

        [Pack("smileyaddonsweat")]
        Sweat = 5,

        [Pack("pro")]
        Tear = 6,

        [Pack("smileyaddonwhiskers")]
        Whiskers = 7,
    }
    public enum SmileyAbove
    {
        Nothing = 0,

        [Pack("smileyabovebunny")]
        BunnyEars = 1,

        [Pack("brickguitar")]
        CountrySingerHat = 2,

        [Pack("smileyabovedevil")]
        DevilHorns = 3,

        [Pack("smileyabovedoctor")]
        Doctor = 4,

        [Pack("smileyabovegargoyle")]
        GargoyleHorns = 5,


        Halo = 6,

        [Pack("smileyabovenewyear")]
        NewYear2010 = 7,

        [Pack("smileyabovenurse")]
        NurseHat = 8,

        [Pack("-")]
        PartyHat1 = 9,

        [Pack("-")]
        PartyHat2 = 10,

        [Pack("-")]
        PartyHat3 = 11,

        [Pack("-")]
        PartyHat4 = 12,

        Pigtails = 13,

        [Pack("smileyabovepirate")]
        PirateHat = 14,

        [Pack("smileyabovepostman")]
        PostmanHat = 15,

        [Pack("smileyabovesanta")]
        SantaHat = 16,

        [Pack("smileyabovetophat")]
        Tophat = 17,

        [Pack("smileyaboveturban")]
        Turban = 18,

        [Pack("smileyabovetoykey")]
        WindupToyKey = 19,

        [Pack("brickdrums")]
        DjHeadPhones = 20,

        [Pack("bricknode")]
        MusicianHair = 21,

        [Pack("smileyabovegraduate")]
        GraduateHat = 22,

        [Pack("smileyabovewizard")]
        Wizard = 23,

        [Pack("smileyabovefirewizard")]
        FireWizard = 24,

        [Pack("smileyaboveartist")]
        Artist = 25,

        [Pack("-", GoldMembershipItem = true)]
        GoldTopHat = 26,
    }

    public enum SmileyWings
    {
        Nothing = 0,
        Angel = 1,
        Bat = 2,
        Butterfly = 3,
        Gargoyle = 4,
        Seagull = 5,
        Superman = 6,
    }

    public enum SmileyBelow
    {
        Nothing = 0,

        [Pack("smileybelowbeard")]
        Beard = 1,

        [Pack("smileybelowbowtie1")]
        BowTie1 = 2,

        [Pack("smileybelowbowtie2")]
        BowTie2 = 3,

        [Pack("smileybelowbowtie3")]
        BowTie3 = 4,

        [Pack("smileybelowscarf")]
        Scarf = 5,

        [Pack("smileybelowwizard")]
        WizardBeard = 6,

        [Pack("smileysuper")]
        Superman = 7,

        [Pack("bricknode")]
        MusicianBowTie =8,
    }
    
}
