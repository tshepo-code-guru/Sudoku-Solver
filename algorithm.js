class Algorithm {
    constructor(board) {
        this.board = board;
    }

    isSafe(board, row, col, num) {
        for (let d = 0; d < board.length; d++)
            if (board[row, d] == num)
                return false;

        for (let r = 0; r < board.length; r++)
            if (board[r, col] == num)
                return false;

        let sqrt = parseInt(Math.sqrt(board.length));
        let rowStart = row - row % sqrt;
        let colStart = col - col % sqrt;

        for (let r = rowStart; r < rowStart + sqrt; r++)
            for (var d = colStart; d < colStart + sqrt; d++)
                if (board[r, d] == num)
                    return false;

        return true;
    }

    process() {
        var row = -1, col = -1;
        var isEmpty = true;

        for (let i = 0; i < this.board.length; i++) {
            for (let j = 0; j < this.board.length; j++) {
                if (this.board[i, j] == 0) {
                    row = i;
                    col = j;
                    isEmpty = false;
                    break;
                }
            }

            if (!isEmpty)
                break;
        }

        if (isEmpty)
            return true;

        for (let num = 1; num <= this.board.length; num++) {
            if (this.isSafe(this.board, row, col, num)) {
                this.board[row, col] = num;
                if (this.process())
                    return true;
                else
                    this.board[row, col] = 0;
            }
        }

        return false;
    }

    print() {
        for (let r = 0; r < this.board.length; r++) {
            for (let d = 0; d < this.board.length; d++) {
                console.log(this.board[r, d]);
                console.log(' ');
            }

            console.log('\n');

            if ((r + 1) % parseInt(Math.sqrt(this.board.length)) == 0)
                console.log('');
        }
    }

    solve(board) {
        console.log('Solving. . .');
        console.log('This may take more than a minute depending on the complexity of the puzzle. . .\n');
        if (arguments.length > 0)
            this.board = board;

        this.process();
        this.print();

        console.log('Process Complete!');

        return this.board;
    }
}
