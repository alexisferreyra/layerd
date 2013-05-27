Zoe.createNamespace("game");

game.Actor = Class.$define("game.Actor");
game.PacmanSoul = Class.$define("game.PacmanSoul", game.Actor);

game.Pacman = Class.$define("game.Pacman", game.PacmanSoul, {
    __init__: function(map, row, column, color) {
        this.$super(map, row, column, color);
        if (arguments.length > 0)
        {
        }
    },
    
});


