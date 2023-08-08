﻿namespace Esourcing.UI.ViewModel
{
    public class APIResponseDTO<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
