
// 'use strict';
// // Revenue Growth - Bar Chart
// // --------------------------------------------------------------------
// const barChartEl = document.querySelector('#barChart'),
//   barChartConfig = {
//     chart: {
//       height: 400,
//       type: 'bar',
//       stacked: true,
//       parentHeightOffset: 0,
//       toolbar: {
//         show: false
//       }
//     },
//     plotOptions: {
//       bar: {
//         columnWidth: '15%',
//         colors: {
//           backgroundBarColors: [
//             chartColors.column.bg,
//             chartColors.column.bg,
//             chartColors.column.bg,
//             chartColors.column.bg,
//             chartColors.column.bg
//           ],
//           backgroundBarRadius: 10
//         }
//       }
//     },
//     dataLabels: {
//       enabled: false
//     },
//     legend: {
//       show: true,
//       position: 'top',
//       horizontalAlign: 'start',
//       labels: {
//         colors: legendColor,
//         useSeriesColors: false
//       }
//     },
//     colors: [chartColors.column.series1, chartColors.column.series2],
//     stroke: {
//       show: true,
//       colors: ['transparent']
//     },
//     grid: {
//       borderColor: borderColor,
//       xaxis: {
//         lines: {
//           show: true
//         }
//       }
//     },
//     series: [
//       {
//         name: 'Apple',
//         data: [90, 120, 55, 100, 80, 125, 175, 70, 88, 180]
//       },
//       {
//         name: 'Samsung',
//         data: [85, 100, 30, 40, 95, 90, 30, 110, 62, 20]
//       }
//     ],
//     xaxis: {
//       categories: ['7/12', '8/12', '9/12', '10/12', '11/12', '12/12', '13/12', '14/12', '15/12', '16/12'],
//       axisBorder: {
//         show: false
//       },
//       axisTicks: {
//         show: false
//       },
//       labels: {
//         style: {
//           colors: labelColor,
//           fontSize: '13px'
//         }
//       }
//     },
//     yaxis: {
//       labels: {
//         style: {
//           colors: labelColor,
//           fontSize: '13px'
//         }
//       }
//     },
//     fill: {
//       opacity: 1
//     }
//   };
// if (typeof barChartEl !== undefined && barChartEl !== null) {
//   const barChart = new ApexCharts(barChartEl, barChartConfig);
//   barChart.render();
// }
'use strict';
(function () {
  let cardColor, headingColor, axisColor, borderColor, shadeColor;

  if (isDarkStyle) {
    cardColor = config.colors_dark.cardColor;
    headingColor = config.colors_dark.headingColor;
    axisColor = config.colors_dark.axisColor;
    borderColor = config.colors_dark.borderColor;
    shadeColor = 'dark';
  } else {
    cardColor = config.colors.white;
    headingColor = config.colors.headingColor;
    axisColor = config.colors.axisColor;
    borderColor = config.colors.borderColor;
    shadeColor = 'light';
  }

const revenueGrowthChartEl =  document.querySelector('#barChartone'),
    revenueGrowthChartConfig = {
      chart: {
              height: 200,
              type: 'bar',
              stacked: true,
              parentHeightOffset: 0,
              toolbar: {
                show: false
              }
      },
      grid: {
        show: false,
        padding: {
          left: 0,
          right: 0,
          top: -20,
          bottom: -20
        }
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '20%',
          borderRadius: 2,
          startingShape: 'rounded',
          endingShape: 'flat'
        }
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      colors: [config.colors.info, config.colors_label.secondary],
      series: [
        {
          name: '2020',
          data: [80, 60, 125, 40, 50, 30, 70, 80, 100, 40, 80, 60, 120, 75, 25, 135, 65]
        },
        {
          name: '2021',
          data: [50, 65, 40, 100, 30, 30, 80, 20, 50, 45, 30, 90, 70, 40, 50, 40, 60]
        }
      ],
      xaxis: {
        categories: ['10', '', '', '', '', '', '', '', '15', '', '', '', '', '', '', '', '20'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: axisColor
          },
          offsetY: -5
        }
      },
      yaxis: {
        show: false,
        floating: true
      },
      tooltip: {
        x: {
          show: false
        }
      }
    };
  if (typeof revenueGrowthChartEl !== undefined && revenueGrowthChartEl !== null) {
    const revenueGrowthChart = new ApexCharts(revenueGrowthChartEl, revenueGrowthChartConfig);
    revenueGrowthChart.render();
  }

  const revenueGrowthChartE2 =  document.querySelector('#barCharttwo'),
    revenueGrowthChartConfigtwo = {
      chart: {
              height: 200,
              type: 'bar',
              stacked: true,
              parentHeightOffset: 0,
              toolbar: {
                show: false
              }
      },
      grid: {
        show: false,
        padding: {
          left: 0,
          right: 0,
          top: -20,
          bottom: -20
        }
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '20%',
          borderRadius: 2,
          startingShape: 'rounded',
          endingShape: 'flat'
        }
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      colors: [config.colors.info, config.colors_label.secondary],
      series: [
        {
          name: '2020',
          data: [80, 60, 125, 40, 50, 30, 70, 80, 100, 40, 80, 60, 120, 75, 25, 135, 65]
        },
        {
          name: '2021',
          data: [50, 65, 40, 100, 30, 30, 80, 20, 50, 45, 30, 90, 70, 40, 50, 40, 60]
        }
      ],
      xaxis: {
        categories: ['10', '', '', '', '', '', '', '', '15', '', '', '', '', '', '', '', '20'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: axisColor
          },
          offsetY: -5
        }
      },
      yaxis: {
        show: false,
        floating: true
      },
      tooltip: {
        x: {
          show: false
        }
      }
    };
  if (typeof revenueGrowthChartE2 !== undefined && revenueGrowthChartE2 !== null) {
    const revenueGrowthCharttwo = new ApexCharts(revenueGrowthChartE2, revenueGrowthChartConfigtwo);
    revenueGrowthCharttwo.render();
  }

  const revenueGrowthChartE3 =  document.querySelector('#barChartthree'),
    revenueGrowthChartConfigthree = {
      chart: {
              height: 200,
              type: 'bar',
              stacked: true,
              parentHeightOffset: 0,
              toolbar: {
                show: false
              }
      },
      grid: {
        show: false,
        padding: {
          left: 0,
          right: 0,
          top: -20,
          bottom: -20
        }
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '20%',
          borderRadius: 2,
          startingShape: 'rounded',
          endingShape: 'flat'
        }
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      colors: [config.colors.info, config.colors_label.secondary],
      series: [
        {
          name: '2020',
          data: [80, 60, 125, 40, 50, 30, 70, 80, 100, 40, 80, 60, 120, 75, 25, 135, 65]
        },
        {
          name: '2021',
          data: [50, 65, 40, 100, 30, 30, 80, 20, 50, 45, 30, 90, 70, 40, 50, 40, 60]
        }
      ],
      xaxis: {
        categories: ['10', '', '', '', '', '', '', '', '15', '', '', '', '', '', '', '', '20'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: axisColor
          },
          offsetY: -5
        }
      },
      yaxis: {
        show: false,
        floating: true
      },
      tooltip: {
        x: {
          show: false
        }
      }
    };
  if (typeof revenueGrowthChartE3 !== undefined && revenueGrowthChartE3 !== null) {
    const revenueGrowthChartthree = new ApexCharts(revenueGrowthChartE3, revenueGrowthChartConfigthree);
    revenueGrowthChartthree.render();
  }

  const revenueGrowthChartE4 =  document.querySelector('#barChartfour'),
    revenueGrowthChartConfigfour = {
      chart: {
              height: 200,
              type: 'bar',
              stacked: true,
              parentHeightOffset: 0,
              toolbar: {
                show: false
              }
      },
      grid: {
        show: false,
        padding: {
          left: 0,
          right: 0,
          top: -20,
          bottom: -20
        }
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '20%',
          borderRadius: 2,
          startingShape: 'rounded',
          endingShape: 'flat'
        }
      },
      legend: {
        show: false
      },
      dataLabels: {
        enabled: false
      },
      colors: [config.colors.info, config.colors_label.secondary],
      series: [
        {
          name: '2020',
          data: [80, 60, 125, 40, 50, 30, 70, 80, 100, 40, 80, 60, 120, 75, 25, 135, 65]
        },
        {
          name: '2021',
          data: [50, 65, 40, 100, 30, 30, 80, 20, 50, 45, 30, 90, 70, 40, 50, 40, 60]
        }
      ],
      xaxis: {
        categories: ['10', '', '', '', '', '', '', '', '15', '', '', '', '', '', '', '', '20'],
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: axisColor
          },
          offsetY: -5
        }
      },
      yaxis: {
        show: false,
        floating: true
      },
      tooltip: {
        x: {
          show: false
        }
      }
    };
  if (typeof revenueGrowthChartE4 !== undefined && revenueGrowthChartE4 !== null) {
    const revenueGrowthChartfour = new ApexCharts(revenueGrowthChartE4, revenueGrowthChartConfigfour);
    revenueGrowthChartfour.render();
  }

  
})();
