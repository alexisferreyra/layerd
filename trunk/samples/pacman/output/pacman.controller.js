// JavaScript specific imports

// my project imports
Zoe.createNamespace("game");

game.Controller = Class.$define("game.Controller", {
    __init__: function() {
        // instance fields
        this._canvas = null;
        this._context = null;
        this._pacman = null;
        this._badPacman = null;
    },
    
    $copy: function() {
        var copyObject = new game.Controller();
        copyObject._canvas = this._canvas;
        copyObject._context = this._context;
        copyObject._pacman = this._pacman;
        copyObject._badPacman = this._badPacman;
        return copyObject;
    },
    
    run: function() {
        this.renderBody();
        var map = new game.Map(this._context, this._canvas.width, this._canvas.height);
        map.render();
        this._pacman = new game.BadPacman(map, 1, 1, "blue");
        this._pacman.render();
        this._badPacman = new game.BadPacman(map, map.rows() - 2, map.columns() - 2, "red");
        this._badPacman.render();
        this._pacman.setOtherPacman(this._badPacman);
        this._badPacman.setOtherPacman(this._pacman);
        // render timer
        var $that = this;
        window.setInterval(function() {
            map.renderAround($that._pacman.row(), $that._pacman.column());
            map.renderAround($that._badPacman.row(), $that._badPacman.column());
            
            $that._pacman.updateAnimation();
            $that._pacman.render();
            $that._badPacman.updateAnimation();
            $that._badPacman.render();
        }, 1000 / 60);
        
        window.onkeyup = function(event) {
            // up
            if (event.keyCode === 38)
            {
                $that._pacman.changeDirection(game.Actor.Up);
                event.preventDefault();
            }
            // down
            
            if (event.keyCode === 40)
            {
                $that._pacman.changeDirection(game.Actor.Down);
                event.preventDefault();
            }
            // left
            
            if (event.keyCode === 37)
            {
                $that._pacman.changeDirection(game.Actor.Left);
                event.preventDefault();
            }
            // right
            
            if (event.keyCode === 39)
            {
                $that._pacman.changeDirection(game.Actor.Right);
                event.preventDefault();
            }
        };
    },
    
    renderBody: function() {
        this._canvas = document.createElement("canvas");
        this._canvas.width = window.innerWidth;
        this._canvas.height = window.innerHeight;
        
        this._context = this._canvas.getContext("2d");
        var mainDiv = document.getElementById("main-page");
        mainDiv.appendChild(this._canvas);
        
        this._context.setFillColor("#000");
        this._context.fillRect(0, 0, this._canvas.width, this._canvas.height);
    },
    
});

game.Controller.Main = function() {
    new game.Controller().run();
    console.log("HTML5 Pacman Started!");
};


