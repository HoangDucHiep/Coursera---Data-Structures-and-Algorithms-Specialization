// by Alexander Nikolskiy

const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    terminal: false
});

process.stdin.setEncoding('utf8');
rl.on('line', readLine);

function readLine(line) {
    console.log(fib(parseInt(line, 10)));
    process.exit();
}

function fib(n) {
    // write your code here
    let fibNum = [0, 1, 1];
    for (let i = 3; i <= n; i++) {
        fibNum.push(fibNum[i - 1] + fibNum[i - 2])
    }
    return fibNum[n]
}

module.exports = fib;
