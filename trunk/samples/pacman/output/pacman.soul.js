Zoe.createNamespace("game");

game.Actor = Class.$define("game.Actor");

game.PacmanSoul = Class.$define("game.PacmanSoul", game.Actor, {
    __init__: function(map, row, column, color) {
        // instance fields
        this._mouthSize = 0;
        this._mouthSizeIncrement = 0;
        this.maxMouthSize = Math.PI / 3;
        this._otherPacman = null;
        this._color = null;
        this._pacmanRadius = 0;
        this.$super(map, row, column, color);
        if (arguments.length > 0)
        {
            this._mouthSize = 0;
            this._mouthSizeIncrement = this.maxMouthSize / 15;
            this._color = color;
            this._pacmanRadius = Math.round(this._cellSize / 2 * 0.8);
        }
    },
    
    $copy: function() {
        var copyObject = new game.PacmanSoul();
        copyObject._mouthSize = this._mouthSize;
        copyObject._mouthSizeIncrement = this._mouthSizeIncrement;
        copyObject.maxMouthSize = this.maxMouthSize;
        copyObject._otherPacman = this._otherPacman;
        copyObject._color = this._color;
        copyObject._pacmanRadius = this._pacmanRadius;
        return copyObject;
    },
    
    setOtherPacman: function(actor) {
        this._otherPacman = actor;
    },
    
    render: function() {
        var arcOffset = 0;
        if (this._direction === game.Actor.Left)
        {
            arcOffset = Math.PI;
        }
        if (this._direction === game.Actor.Up)
        {
            arcOffset = -Math.PI / 2;
        }
        if (this._direction === game.Actor.Down)
        {
            arcOffset = Math.PI / 2;
        }
        
        var x = this._map.xOffset() + this._cellSize * this._column;
        var y = this._map.yOffset() + this._cellSize * this._row;
        var centerX = x + this._cellSize / 2 + this._xOffset;
        var centerY = y + this._cellSize / 2 + this._yOffset;
        
        this._context.beginPath();
        this._context.fillStyle = this._color;
        this._context.arc(centerX, centerY, this._pacmanRadius, this._mouthSize + arcOffset, 2.0 * Math.PI - this._mouthSize + arcOffset, false);
        this._context.lineTo(centerX, centerY);
        this._context.fill();
        this._context.lineWidth = 1;
        this._context.strokeStyle = this._color;
        this._context.stroke();
    },
    
    movedToCell: function(row, column) {
        var cellState = this._map.getCellState(row, column);
        if (cellState === game.Map.P)
        {
            this._otherPacman.setSpeed(game.Actor.Slow);
            this.setSpeed(game.Actor.Fast);
            var $that = this;
            window.setTimeout(function() {
                $that._otherPacman.setSpeed(game.Actor.Normal);
                $that.setSpeed(game.Actor.Normal);
            }, 5000);
        }
        
        this._map.eat(row, column);
    },
    
    updateAnimation: function() {
        this._mouthSize += this._mouthSizeIncrement;
        if (Math.abs(this._mouthSize - this.maxMouthSize) <= 0.0001)
        {
            this._mouthSize = 0;
        }
        
        this.$super();
    },
    
});


