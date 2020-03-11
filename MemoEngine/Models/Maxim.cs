using System;

namespace MemoEngine.Models
{
    /// <summary>
    /// Maxim 모델 클래스
    /// </summary>
    public class Maxim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}