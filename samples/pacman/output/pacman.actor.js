Zoe.createNamespace("game");

game.Actor = Class.$define("game.Actor", {
    __init__: function(map, row, column) {
        // instance fields
        this._map = null;
        this._row = 0;
        this._column = 0;
        this._rowTo = 0;
        this._columnTo = 0;
        this._context = null;
        this._cellSize = 0;
        this._direction = 0;
        this._xOffset = 0;
        this._yOffset = 0;
        this._offsetIncrement = 0;
        this._nextDirection = 0;
        if (arguments.length > 0)
        {
            this._map = map;
            this._row = row;
            this._column = column;
            this._rowTo = this._row;
            this._columnTo = this._column;
            this._context = map.getCanvasContext();
            this._cellSize = map.getCellSize();
            this._direction = game.Actor.Right;
            this._nextDirection = game.Actor.Right;
            this._offsetIncrement = this._cellSize / game.Actor.Normal;
        }
    },
    
    $copy: function() {
        var copyObject = new game.Actor();
        copyObject._map = this._map;
        copyObject._row = this._row;
        copyObject._column = this._column;
        copyObject._rowTo = this._rowTo;
        copyObject._columnTo = this._columnTo;
        copyObject._context = this._context;
        copyObject._cellSize = this._cellSize;
        copyObject._direction = this._direction;
        copyObject._xOffset = this._xOffset;
        copyObject._yOffset = this._yOffset;
        copyObject._offsetIncrement = this._offsetIncrement;
        copyObject._nextDirection = this._nextDirection;
        return copyObject;
    },
    
    render: function() {
    },
    
    updateState: function() {
    },
    
    movedToCell: function(row, column) {
    },
    
    setSpeed: function(speed) {
        this._offsetIncrement = this._cellSize / speed;
    },
    
    getNextX: function(direction) {
        if (direction === game.Actor.Right)
        {
            return 1;
        }
        if (direction === game.Actor.Left)
        {
            return -1;
        }
        return 0;
    },
    
    getNextY: function(direction) {
        if (direction === game.Actor.Up)
        {
            return -1;
        }
        if (direction === game.Actor.Down)
        {
            return 1;
        }
        return 0;
    },
    
    updateAnimation: function() {
        if (this._rowTo === this._row && this._columnTo === this._column)
        {
            return;
        }
        if (Math.abs(this._xOffset) >= this._cellSize || Math.abs(this._yOffset) >= this._cellSize)
        {
            this._row = this._rowTo;
            this._column = this._columnTo;
            // move to next cell
            
            this.resetAnimationOffset();
            // update current cell state
            
            this.movedToCell(this._rowTo, this._columnTo);
            // check if we can move into next direction
            
            this.moveToNextDirection();
        }
        else 
        {
            var nextX = this.getNextX(this._direction);
            var nextY = this.getNextY(this._direction);
            this._xOffset += nextX * this._offsetIncrement;
            this._yOffset += nextY * this._offsetIncrement;
        }
    },
    
    resetAnimationOffset: function() {
        this._xOffset = 0;
        this._yOffset = 0;
    },
    
    moveToNextDirection: function() {
        if (Math.abs(this._xOffset) >= this._cellSize / 10 || Math.abs(this._yOffset) >= this._cellSize / 10)
        {
            return;
        }
        
        var nextX = this.getNextX(this._nextDirection);
        var nextY = this.getNextY(this._nextDirection);
        var cellState = this._map.getCellState(this._row + nextY, this._column + nextX);
        if (cellState !== game.Map.W)
        {
            this._columnTo = this._column + nextX;
            this._rowTo = this._row + nextY;
            this._direction = this._nextDirection;
        }
    },
    
    changeDirection: function(newDirection) {
        this._nextDirection = newDirection;
        this.moveToNextDirection();
    },
    
    getBestDirections: function() {
        var ret = new Array();
        
        var cellState = this._map.getCellState(this._row + 1, this._column);
        if (cellState === game.Map.B)
        {
            ret.push(game.Actor.Down);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Down);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Down);
        }
        
        cellState = this._map.getCellState(this._row - 1, this._column);
        if (cellState === game.Map.B)
        {
            ret.push(game.Actor.Up);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Up);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Up);
        }
        
        cellState = this._map.getCellState(this._row, this._column + 1);
        if (cellState === game.Map.B)
        {
            ret.push(game.Actor.Right);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Right);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Right);
        }
        
        cellState = this._map.getCellState(this._row, this._column - 1);
        if (cellState === game.Map.B)
        {
            ret.push(game.Actor.Left);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Left);
        }
        if (cellState === game.Map.P)
        {
            ret.push(game.Actor.Left);
        }
        
        return ret;
    },
    
    getFreeDirections: function() {
        var ret = new Array();
        
        var cellState = this._map.getCellState(this._rowTo + 1, this._columnTo);
        if (cellState !== game.Map.W)
        {
            ret.push(game.Actor.Down);
        }
        
        cellState = this._map.getCellState(this._rowTo - 1, this._columnTo);
        if (cellState !== game.Map.W)
        {
            ret.push(game.Actor.Up);
        }
        
        cellState = this._map.getCellState(this._rowTo, this._columnTo + 1);
        if (cellState !== game.Map.W)
        {
            ret.push(game.Actor.Right);
        }
        
        cellState = this._map.getCellState(this._rowTo, this._columnTo - 1);
        if (cellState !== game.Map.W)
        {
            ret.push(game.Actor.Left);
        }
        
        return ret;
    },
    
    column: function() {
        return this._column;
    },
    
    row: function() {
        return this._row;
    },
    
});

game.Actor.Up = 1;

game.Actor.Down = 2;

game.Actor.Left = 3;

game.Actor.Right = 4;

game.Actor.Stop = 5;

game.Actor.Normal = 15;

Object.defineProperty(game.Actor, "Slow", 
    { get : function(){ return 15 * 3; } });

Object.defineProperty(game.Actor, "Fast", 
    { get : function(){ return 15 / 1.5; } });


