function set() {
    const profitData = [1000, 1200, 1500, 1800, 2000];
    const expensesData = [800, 900, 1000, 1100, 1200];
    const incomeData = [200, 300, 500, 700, 800];
    const ordersData = [10, 12, 15, 18, 20];

    function createChart(data, containerId) {
        const container = document.getElementById(containerId);
        const chart = new Chart(container, {
            type: 'line',
            data: {
                labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
                datasets: [{
                    label: containerId.split("-")[0].toUpperCase(),
                    data: data,
                    borderColor: 'blue',
                    backgroundColor: 'rgba(0, 0, 255, 0.1)',
                    
                }]
            }

        });
    }

    createChart(profitData, 'profit-chart');
    createChart(expensesData, 'expenses-chart');
    createChart(incomeData, 'income-chart');
    createChart(ordersData, 'orders-chart');
}
function set2() {
    const ctx = document.getElementById('profit-chart');

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
            datasets: [{
                label: '# of Votes',
                data: [12, 19, 3, 5, 2, 3],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    const ctx2 = document.getElementById('expenses-chart');

    new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
            datasets: [{
                label: '# of Votes',
                data: [12, 19, 3, 5, 2, 12],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

set();




