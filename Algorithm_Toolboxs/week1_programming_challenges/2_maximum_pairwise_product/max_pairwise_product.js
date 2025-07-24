const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    terminal: false
});

process.stdin.setEncoding('utf8');
rl.once('line', () => {
    rl.on('line', readLine);
});

function readLine (line) {
    const arr = line.toString().split(' ').map(Number);

    console.log(max(arr));
    process.exit();
}

function max(arr) {
    let n = arr.length;
    let maxIdx = 0;
    // write your code here
    for (let i = 1; i < n; i++) {
        if (arr[i] > arr[maxIdx]) {
            maxIdx = i;
        }
    }

    [arr[maxIdx], arr[n - 1]] = [arr[n - 1], arr[maxIdx]];

    maxIdx = 0;

    for (let i = 1; i < n - 1; i++) {
        if (arr[i] > arr[maxIdx]) {
            maxIdx = i;
        }
    }

    return arr[n - 1] * arr[maxIdx];
}

module.exports = max;
