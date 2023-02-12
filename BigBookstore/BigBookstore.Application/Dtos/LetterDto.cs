using BigBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Dtos
{
    public class LetterDto : BaseDto<LetterDto, Letter>
    {
        public string Name { get; set; }

        public override LetterDto Projection(Letter entity)
        {
            return new LetterDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
