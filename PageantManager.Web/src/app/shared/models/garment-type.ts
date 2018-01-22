import { Garment } from './garment';
import { GarmentMeasurementType } from './garment-measurement-type';

export class GarmentType {
  garmentTypeId: number;
  name: string;
  description: string;
  photo: string;
  garments: Garment[];
  garmentMeasurementTypes: GarmentMeasurementType[];
}
