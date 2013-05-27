Zoe.createNamespace("game");

game.Map = Class.$define("game.Map", {
    __init__: function(context, width, height) {
        // instance fields
        this._map = null;
        this._context = null;
        this._pixelWidth = 0;
        this._pixelHeight = 0;
        this._cellSize = 0;
        this._xOffset = 0;
        this._yOffset = 0;
        this._ballRadius = 0;
        this._powerRadius = 0;
        this._columns = 0;
        this._rows = 0;
        this._ballsCount = 0;
        this._totalBallsCount = 0;
        if (arguments.length > 0)
        {
            
            this._context = context;
            this._pixelWidth = width;
            this._pixelHeight = height;
            this.initialize();
        }
    },
    
    $copy: function() {
        var copyObject = new game.Map();
        copyObject._map = this._map;
        copyObject._context = this._context;
        copyObject._pixelWidth = this._pixelWidth;
        copyObject._pixelHeight = this._pixelHeight;
        copyObject._cellSize = this._cellSize;
        copyObject._xOffset = this._xOffset;
        copyObject._yOffset = this._yOffset;
        copyObject._ballRadius = this._ballRadius;
        copyObject._powerRadius = this._powerRadius;
        copyObject._columns = this._columns;
        copyObject._rows = this._rows;
        copyObject._ballsCount = this._ballsCount;
        copyObject._totalBallsCount = this._totalBallsCount;
        return copyObject;
    },
    
    initialize: function() {
        this.fillMap();
        
        this._columns = (this._map[0]).length;
        this._rows = this._map.length;
        
        var maxWidth = Math.round(this._pixelWidth / this._columns);
        var maxHeight = Math.round(this._pixelHeight / this._rows);
        
        this._cellSize = Math.min(maxWidth, maxHeight);
        
        this._xOffset = Math.round((this._pixelWidth - this._cellSize * this._columns) / 2);
        this._yOffset = Math.round((this._pixelHeight - this._cellSize * this._rows) / 2);
        this._ballRadius = Math.round(this._cellSize * 0.05);
        this._powerRadius = Math.round(this._cellSize * 0.15);
    },
    
    drawMap: function() {
        var mapColumns = this._columns;
        var mapRows = this._rows;
        
        for (var r = 0; r < mapRows; r++)
        {
            for (var c = 0; c < mapColumns; c++)
            {
                var cellState = this.getCellState(r, c);
                if (cellState === game.Map.B || cellState === game.Map.P)
                {
                    this._totalBallsCount++;
                }
                this.renderRowColumn(r, c, true);
            }
        }
        
        this._ballsCount = this._totalBallsCount;
    },
    
    renderRowColumn: function(row, column, renderWall) {
        if (row < 0 || column < 0)
        {
            return;
        }
        
        var cellType = this._map[row][column];
        
        var x = this._xOffset + this._cellSize * column;
        var y = this._yOffset + this._cellSize * row;
        
        if (cellType === game.Map.W && renderWall)
        {
            this.renderWall(x, y);
        }
        if (cellType === game.Map.F || cellType === game.Map.FB || cellType === game.Map.FP)
        {
            this.renderFreeSpace(x, y);
        }
        if (cellType === game.Map.B)
        {
            this.renderBall(x, y);
        }
        if (cellType === game.Map.P)
        {
            this.renderPowerBall(x, y);
        }
    },
    
    renderWall: function(x, y) {
        var grd = this._context.createRadialGradient(238, 50, 10, 238, 50, 300);
        grd.addColorStop(0, "#8ED6FF");
        grd.addColorStop(1, "#004CB3");
        this._context.fillStyle = grd;
        this._context.fillRect(x, y, this._cellSize, this._cellSize);
    },
    
    renderFreeSpace: function(x, y) {
        this._context.setFillColor("#FFF");
        this._context.fillRect(x, y, this._cellSize, this._cellSize);
    },
    
    renderBall: function(x, y) {
        var centerX = x + this._cellSize / 2;
        var centerY = y + this._cellSize / 2;
        this.renderFreeSpace(x, y);
        this._context.beginPath();
        this._context.arc(centerX, centerY, this._ballRadius, 0, 2.0 * Math.PI, false);
        this._context.fillStyle = "green";
        this._context.fill();
        this._context.lineWidth = 1;
        this._context.strokeStyle = "#003300";
        this._context.stroke();
    },
    
    renderPowerBall: function(x, y) {
        var centerX = x + this._cellSize / 2;
        var centerY = y + this._cellSize / 2;
        this.renderFreeSpace(x, y);
        this._context.beginPath();
        this._context.arc(centerX, centerY, this._powerRadius, 0, 2.0 * Math.PI, false);
        this._context.fillStyle = "green";
        this._context.fill();
        this._context.lineWidth = 1;
        this._context.strokeStyle = "#003300";
        this._context.stroke();
    },
    
    eat: function(row, column) {
        var cellState = this.getCellState(row, column);
        if (cellState === game.Map.B || cellState === game.Map.P)
        {
            this.changeCellState(row, column, (((cellState === game.Map.B)) ? (game.Map.FB) : (game.Map.FP)));
            this._ballsCount--;
            if (this._ballsCount % 50 === 0 || this._ballsCount < 10)
            {
                console.log("Balls Count: " + this._ballsCount);
            }
        }
        
        if (this._ballsCount === 0)
        {
            this.resetMap();
        }
    },
    
    resetMap: function() {
        console.log("Reset!");
        var mapColumns = this._columns;
        var mapRows = this._rows;
        
        for (var r = 0; r < mapRows; r++)
        {
            for (var c = 0; c < mapColumns; c++)
            {
                var cellState = this.getCellState(r, c);
                if (cellState === game.Map.FB || cellState === game.Map.FP)
                {
                    this.changeCellState(r, c, (((cellState === game.Map.FB)) ? (game.Map.B) : (game.Map.P)));
                    this.renderRowColumn(r, c, false);
                }
            }
        }
        
        this._ballsCount = this._totalBallsCount;
    },
    
    renderAround: function(row, column) {
        this.renderRowColumn(row, column, false);
        this.renderRowColumn(row + 1, column, false);
        this.renderRowColumn(row - 1, column, false);
        this.renderRowColumn(row, column + 1, false);
        this.renderRowColumn(row, column - 1, false);
    },
    
    xOffset: function() {
        return this._xOffset;
    },
    
    yOffset: function() {
        return this._yOffset;
    },
    
    rows: function() {
        return this._rows;
    },
    
    columns: function() {
        return this._columns;
    },
    
    fillMap: function() {
        this._map = [[game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W], [game.Map.W, game.Map.F, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.W, game.Map.P, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.W, game.Map.P, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.P, game.Map.W], [game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.P, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.P, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.P, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.P, game.Map.W, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.B, game.Map.B, game.Map.W], [game.Map.W, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.B, game.Map.F, game.Map.W], [game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W, game.Map.W]];
    },
    
    changeCellState: function(row, column, newState) {
        var currentState = this._map[row][column];
        if (currentState !== game.Map.W)
        {
            this._map[row][column] = newState;
            return currentState;
        }
        
        return -1;
    },
    
    getCellSize: function() {
        return this._cellSize;
    },
    
    getCanvasContext: function() {
        return this._context;
    },
    
    render: function() {
        this.drawMap();
    },
    
    getCellState: function(row, column) {
        return this._map[row][column];
    },
    
});

game.Map.F = 0;

game.Map.B = 1;

game.Map.P = 2;

game.Map.W = 3;

game.Map.FB = 4;

game.Map.FP = 5;


