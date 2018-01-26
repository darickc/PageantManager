import { MeasurementType } from './measurement-type';

export class GarmentMeasurement {
  garmentMeasurementId: number;
  garmentId: number;
  measurementTypeId: number;
  min: number;
  max: number;
  measurementType: MeasurementType;

}
