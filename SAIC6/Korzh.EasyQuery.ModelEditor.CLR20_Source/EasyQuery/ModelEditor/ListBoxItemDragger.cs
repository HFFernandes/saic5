namespace Korzh.EasyQuery.ModelEditor
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal class ListBoxItemDragger
    {
        private Cursor dragCursor = Cursors.SizeNS;
        private bool dragging;
        private int dragItemIndex = -1;
        private ListBox listBox;
        private Cursor prevCursor = Cursors.Default;

        public event EventHandler ItemMoved;

        public ListBoxItemDragger(ListBox listBox)
        {
            this.Attach(listBox);
        }

        public void Attach(ListBox listBox)
        {
            this.listBox = listBox;
            this.listBox.MouseDown += new MouseEventHandler(this.MouseDownHandler);
            this.listBox.MouseUp += new MouseEventHandler(this.MouseUpHandler);
            this.listBox.MouseMove += new MouseEventHandler(this.MouseMoveHandler);
        }

        public void Detach()
        {
            this.listBox.MouseDown -= new MouseEventHandler(this.MouseDownHandler);
            this.listBox.MouseUp -= new MouseEventHandler(this.MouseUpHandler);
            this.listBox.MouseMove -= new MouseEventHandler(this.MouseMoveHandler);
        }

        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            this.dragItemIndex = this.listBox.SelectedIndex;
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if ((this.dragItemIndex >= 0) && (e.Y > 0))
            {
                if (!this.dragging)
                {
                    this.dragging = true;
                    this.prevCursor = this.listBox.Cursor;
                    this.listBox.Cursor = this.DragCursor;
                }
                int index = this.listBox.IndexFromPoint(e.X, e.Y);
                if (this.dragItemIndex != index)
                {
                    object item = this.listBox.Items[this.dragItemIndex];
                    this.listBox.BeginUpdate();
                    try
                    {
                        this.listBox.Items.RemoveAt(this.dragItemIndex);
                        if (index != -1)
                        {
                            this.listBox.Items.Insert(index, item);
                        }
                        else
                        {
                            index = this.listBox.Items.Add(item);
                        }
                        this.listBox.SelectedIndex = index;
                    }
                    finally
                    {
                        this.listBox.EndUpdate();
                    }
                    this.dragItemIndex = index;
                    this.OnItemMoved(EventArgs.Empty);
                }
            }
        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            this.dragItemIndex = -1;
            if (this.dragging)
            {
                this.listBox.Cursor = this.prevCursor;
                this.dragging = false;
            }
        }

        protected void OnItemMoved(EventArgs e)
        {
            if (this.ItemMoved != null)
            {
                this.ItemMoved(this, e);
            }
        }

        public Cursor DragCursor
        {
            get
            {
                return this.dragCursor;
            }
            set
            {
                this.dragCursor = value;
            }
        }

        public int DragItemIndex
        {
            get
            {
                return this.dragItemIndex;
            }
        }
    }
}

