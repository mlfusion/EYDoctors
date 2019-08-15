import { Pipe, PipeTransform } from '@angular/core';
import { PatientRating } from '../_models/models';
import { forEach } from '../../../node_modules/@angular/router/src/utils/collection';

@Pipe({
  name: 'average'
})
export class AveragePipe implements PipeTransform {

  transform(ratings: PatientRating[]): any {

      if (ratings.length == 0)
          return 'No review posted.';
         
      let avg = 0;
      let total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0

      
      ratings.forEach((item, index) => {

         // avg += item.rating;

          if (item.rating == 1) {
              total1++
          }
          if (item.rating == 2) {
              total2++
          }
          if (item.rating == 3) {
              total3++
          }
          if (item.rating == 4) {
              total4++
          }
          if (item.rating == 5) {
              total5++
          }

      });
      
      
      avg = (5 * total5 + 4 * total4 + 3 * total3 + 2 * total2 + 1 * total1) /
          (total1 + total2 + total3 + total4 + total5);

      let totalComments = (total1 + total2 + total3 + total4 + total5);

      avg = Math.round(10 * avg) / 10

      //console.log(avg)
      
      return (avg) + ' out of 5 ratings. (' + totalComments + (totalComments == 1 ? ' review' : ' reviews') + ')';
  }

}
