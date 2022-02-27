// show rows
const selestRows = document.querySelector('.selest-rows'),
    rows = document.getElementById('rows'),
    numshow = document.getElementById('numshow');
let numRows = rows.children.length;
numshow.children[1].textContent = numRows + " ";
numshow.children[0].textContent = numRows + " ";
// show 10 rows
selestRows.addEventListener('click', () => {
    numshow.children[0].textContent = "10 ";
    if (selestRows.value == 10) {
        for (let i = 1; i < numRows; i++) {
            if (i > 10) {
                rows.children[i].classList.add('d-none')
            }
        }
    } else if (selestRows.value == 25) {
        numshow.children[0].textContent = "25 ";
        for (let i = 1; i < numRows; i++) {
            if (i > 25) {
                rows.children[i].classList.add('d-none')
            } else {
                rows.children[i].classList.remove('d-none')
            }
        }
    } else {
        numshow.children[0].textContent = "50 ";
        for (let i = 1; i < numRows; i++) {
            if (i > 50) {
                rows.children[i].classList.add('d-none')
            } else {
                rows.children[i].classList.remove('d-none')
            }
        }
    }
})