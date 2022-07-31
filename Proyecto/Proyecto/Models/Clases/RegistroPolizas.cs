using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models.Clases
{
    public class RegistroPolizas
    {
        readonly double procentajeImpuesto = 0.13; //impuesto del 13%
        /// <summary>
        /// validar si la fecha de venciiento de la poliza es mayor a hoy
        /// </summary>
        /// <param name="fecha">fecha de vencimiento de la poliza</param>
        /// <returns></returns>
        public bool ValidarFechaVencimiento(DateTime fechaVencimiento)
        {
            if (fechaVencimiento>DateTime.Now)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcion para calcular el monto recargado de acerdo al numero de adicciones
        /// </summary>
        /// <param name="cantidadAdicciones"></param>
        /// <param name="montoAsegurado"></param>
        /// <returns></returns>
        public double MontoAdicciones(int cantidadAdicciones, double montoAsegurado)
        {
            if (cantidadAdicciones==1)
            {
                return montoAsegurado*0.05; //5% de recargo
            }
            else if(cantidadAdicciones==2 || cantidadAdicciones==3)
            {
                return montoAsegurado*0.10; // 10% de recargo
            }
            else
            {// adicciones >3
                return montoAsegurado*0.15; // 15% de recargo
            }
        }

        public double PrimaAntesImpuestos(double porcentajePrima, double montoAdicciones)
        {
            return montoAdicciones * porcentajePrima;
        }

        public double Impuestos(double primaAntesImpuestos)
        {
            return primaAntesImpuestos* procentajeImpuesto;
        }

        public double PrimaFinal(double primaAntesImpuestos, double impuestos)
        {
            return primaAntesImpuestos + impuestos;
        }
    }
}