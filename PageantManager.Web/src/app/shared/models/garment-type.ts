import { Garment } from './garment';
import { GarmentMeasurementType } from './garment-measurement-type';
import { MeasurementOption } from './measurement-option';

export class GarmentType {
  garmentTypeId: number;
  name: string;
  description: string;
  photo: string;
  garments: Garment[];
  garmentMeasurementTypes: GarmentMeasurementType[];
  measurementOptions: MeasurementOption[];

  public constructor(init?: Partial<GarmentType>) {
    Object.assign(this, init);
  }
}
