Zoe.createNamespace("game");

game.Actor = Class.$define("game.Actor");
game.PacmanSoul = Class.$define("game.PacmanSoul", game.Actor);

game.BadPacman = Class.$define("game.BadPacman", game.PacmanSoul, {
    __init__: function(map, row, column, color) {
        // instance fields
        this._counter = 0;
        this.$super(map, row, column, color);
        if (arguments.length > 0)
        {
        }
    },
    
    $copy: function() {
        var copyObject = new game.BadPacman();
        copyObject._counter = this._counter;
        return copyObject;
    },
    
    updateAnimation: function() {
        var bestDirections = this.getBestDirections();
        var freeDirections = this.getFreeDirections();
        if (bestDirections.length > 0 && bestDirections.indexOf(this._direction) < 0)
        {
            var selected = 0;
            if (bestDirections.length > 1)
            {
                selected = Math.floor(Math.random() * bestDirections.length);
            }
            this.changeDirection(bestDirections[selected]);
        }
        else 
        {
            if (this._row === this._rowTo && this._column === this._columnTo || this._counter > 4 && freeDirections.length > 2)
            {
                var selected = Math.floor(Math.random() * freeDirections.length);
                this.changeDirection(freeDirections[selected]);
                this._counter = 0;
            }
        }
        
        this.$super();
    },
    
    movedToCell: function(row, column) {
        this._counter++;
        this.$super(row, column);
    },
    
});


