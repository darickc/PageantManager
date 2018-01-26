import { MeasurementType } from './measurement-type';

export class GarmentMeasurementType {
  garmentMeasurementTypeId: number;
  garmentTypeId: number;
  measurementTypeId: number;
  measurementType: MeasurementType;

  public constructor(init?: Partial<GarmentMeasurementType>) {
    Object.assign(this, init);
  }
}
