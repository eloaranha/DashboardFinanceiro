//notasFiscais.js
$(document).ready(function () {
    $.ajax({
        url: '/api/dashboard',
        method: 'GET',
        success: function (data) {
            $('#dashboard').html(`
                <p>Total Emitidas: ${data.totalEmitidas}</p>
                <p>Total Inadimplentes: ${data.totalInadimplentes}</p>
                <p>Total Pagas: ${data.totalPagas}</p>
            `);

            var ctx = document.getElementById('inadimplenciaChart').getContext('2d');
            var inadimplenciaChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: data.labels, 
                    datasets: [{
                        label: '# of Votes',
                        data: data.values,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
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
        },
        error: function (error) {
            console.error('Error fetching data:', error);
        }
    });
});