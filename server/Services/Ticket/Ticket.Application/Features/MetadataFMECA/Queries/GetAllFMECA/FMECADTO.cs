﻿using FMECA.Domain.Common.Enum;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllFMECA
{
    public class FMECADTO
    {
        public int FMECAId { get; set; }
        public string FMECAName { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;
        public int TopLevelPartNumber { get; set; }
        public FMECAType FMECAType { get; set; }
        public ProcessFMECAType ProcessFMECAType { get; set; }
    }
}