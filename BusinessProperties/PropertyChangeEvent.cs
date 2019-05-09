namespace BusinessProperties
{
    public class PropertyChangeEvent<T>
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }
}
