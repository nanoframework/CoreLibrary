//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.IO
{
    /// <summary>
    /// Provides a generic view of a sequence of bytes. This is an abstract class.
    /// </summary>
    [Serializable]
    public abstract class Stream : MarshalByRefObject, IDisposable
    {
        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <value>
        /// true if the stream supports reading; otherwise, false.
        /// </value>
        public abstract bool CanRead
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <value>
        /// true if the stream supports seeking; otherwise, false.
        /// </value>
        public abstract bool CanSeek
        {
            get;
        }

        /// <summary>
        /// Gets a value that determines whether the current stream can time out.
        /// </summary>
        /// <value>
        /// A value that determines whether the current stream can time out.
        /// </value>
        public virtual bool CanTimeout
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <value>
        /// true if the stream supports writing; otherwise, false.
        /// </value>
        public abstract bool CanWrite
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class, gets the length in bytes of the stream.
        /// </summary>
        /// <value>
        /// A long value representing the length of the stream in bytes.
        /// </value>
        public abstract long Length
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class, gets or sets the position within the current stream.
        /// </summary>
        /// <value>
        /// The current position within the stream.
        /// </value>
        public abstract long Position
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.
        /// </summary>
        /// <value>
        /// A value, in milliseconds, that determines how long the stream will attempt to read before timing out.
        /// </value>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual int ReadTimeout
        {
            get
            {
                throw new InvalidOperationException();
            }

            set
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.
        /// </summary>
        /// <value>
        /// A value, in milliseconds, that determines how long the stream will attempt to write before timing out.
        /// </value>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual int WriteTimeout
        {
            get
            {
                throw new InvalidOperationException();
            }

            set
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream. 
        /// Instead of calling this method, ensure that the stream is properly disposed.
        /// </summary>
        /// <remarks>
        /// Stream used to require that all cleanup logic went into Close(),
        /// which was thought up before we invented IDisposable.  However, we
        /// need to follow the IDisposable pattern so that users can write
        /// sensible subclasses without needing to inspect all their base
        /// classes, and without worrying about version brittleness, from a
        /// base class switching to the Dispose pattern.  We're moving
        /// Stream to the Dispose(bool) pattern - that's where all subclasses
        /// should put their cleanup starting in V2.
        /// </remarks>
        public virtual void Close()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~Stream()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the Stream and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// When overridden in a derived class, clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        public abstract void Flush();

        /// <summary>
        /// When overridden in a derived class, sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public abstract long Seek(long offset, SeekOrigin origin);

        /// <summary>
        /// When overridden in a derived class, sets the length of the current stream.
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        public abstract void SetLength(long value);

        /// <summary>
        /// When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
        public abstract int Read(byte[] buffer, int offset, int count);

        /// <summary>
        /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        public virtual int ReadByte()
        {
            var oneByteArray = new byte[1];
            var r = Read(oneByteArray, 0, 1);

            if (r == 0) return -1;

            return oneByteArray[0];
        }

        /// <summary>
        /// When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public abstract void Write(byte[] buffer, int offset, int count);

        /// <summary>
        /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
        /// </summary>
        /// <param name="value">The byte to write to the stream.</param>
        public virtual void WriteByte(byte value)
        {
            var oneByteArray = new byte[1];
            oneByteArray[0] = value;
            Write(oneByteArray, 0, 1);
        }
    }
}
