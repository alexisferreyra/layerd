Zoe.createNamespace("game");

game.Actor = Class.$define("game.Actor");
game.PacmanSoul = Class.$define("game.PacmanSoul", game.Actor);

game.BadPacman = Class.$define("game.BadPacman", game.PacmanSoul, {
    __init__: function(map, row, column, color) {
        // instance fields
        this._counter = 0;
        this._disableAuto = false;
        this._enableTimeout = 0;
        this.$super(map, row, column, color);
        if (arguments.length > 0)
        {
            this._disableAuto = false;
            this._enableTimeout = 0;
        }
    },
    
    $copy: function() {
        var copyObject = new game.BadPacman();
        copyObject._counter = this._counter;
        copyObject._disableAuto = this._disableAuto;
        copyObject._enableTimeout = this._enableTimeout;
        return copyObject;
    },
    
    updateAnimation: function() {
        if (this._disableAuto)
        {
            this.$super();
            return;
        }
        
        var bestDirections = this.getBestDirections();
        var freeDirections = this.getFreeDirections();
        if (bestDirections.length > 0 && bestDirections.indexOf(this._direction) < 0)
        {
            var selected = 0;
            if (bestDirections.length > 1)
            {
                selected = Math.floor(Math.random() * bestDirections.length);
            }
            game.Actor.prototype.changeDirection.call(this, bestDirections[selected]);
        }
        else 
        {
            if (this._row === this._rowTo && this._column === this._columnTo || this._counter > 4 && freeDirections.length > 2)
            {
                var selected = Math.floor(Math.random() * freeDirections.length);
                game.Actor.prototype.changeDirection.call(this, freeDirections[selected]);
                this._counter = 0;
            }
        }
        
        this.$super();
    },
    
    changeDirection: function(newDirection) {
        this._disableAuto = true;
        this.$super(newDirection);
        // timeout to enable auto again
        
        if (this._enableTimeout !== 0)
        {
            window.clearTimeout(this._enableTimeout);
        }
        var $that = this;
        this._enableTimeout = window.setTimeout(function() {
            $that._disableAuto = false;
        }, 5000);
    },
    
    movedToCell: function(row, column) {
        this._counter++;
        this.$super(row, column);
    },
    
});


