//site.js
$(document).ready((e) => {
  $('#total_notas_emitidas').text('123');
  $('#total_notas_sem_cobranca').text('23');
  $('#total_notas_vencidas').text('100');
  $('#total_notas_irao_vencer').text('30');
  $('#total_notas_pagas').text('50');
});

const inadimplenciaChart = document.getElementById('inadimplenciaChart');
const graficoReceitaRecebida = document.getElementById('grafico_barras_receitas-recebidas');

new Chart(inadimplenciaChart, {
  type: 'bar',
  data: {
      labels: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto"],
      datasets: [{
          label: 'Inadimplência',
          data: [10, 20, 30, 40, 50, 60, 70, 80]
      }]
  }
});
