import { GarmentMeasurement } from './garment-measurement';

export class Garment {
  garmentId: number;
  garmentTypeId: number;
  addedDate: Date;
  retiredDate?: Date;
  checkedOut: boolean;
  photo: string;
  garmentMeasurements: GarmentMeasurement[];
}
